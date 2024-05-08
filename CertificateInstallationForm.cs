namespace X509CertificateTool
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public partial class CertificateInstallationForm : Form
    {
        public CertificateInstallationForm()
        {
            InitializeComponent();

            SetupListbox(listBoxCurrentUserMy, new CertLocation(StoreLocation.CurrentUser, StoreName.My));
            SetupListbox(listBoxCurrentUserAddressBook, new CertLocation(StoreLocation.CurrentUser, StoreName.AddressBook));
            SetupListbox(listBoxCurrentUserTrustedPeople, new CertLocation(StoreLocation.CurrentUser, StoreName.TrustedPeople));
            SetupListbox(listBoxCurrentUserRoot, new CertLocation(StoreLocation.CurrentUser, StoreName.Root));

            SetupListbox(listBoxLocalMachineMy, new CertLocation(StoreLocation.LocalMachine, StoreName.My));
            SetupListbox(listBoxLocalMachineAddressBook, new CertLocation(StoreLocation.LocalMachine, StoreName.AddressBook));
            SetupListbox(listBoxLocalMachineTrustedPeople, new CertLocation(StoreLocation.LocalMachine, StoreName.TrustedPeople));
            SetupListbox(listBoxLocalMachineRoot, new CertLocation(StoreLocation.LocalMachine, StoreName.Root));
        }

        private void SetupListbox(ListBox listBox, CertLocation certLocation)
        {
            Debug.Assert(null != listBox, "null != listBox");
            Debug.Assert(null != certLocation, "null != certLocation");

            listBox.Tag = certLocation;
            listBox.HorizontalScrollbar = true;
            listBox.AllowDrop = true;
            listBox.SelectionMode = SelectionMode.MultiExtended;
            listBox.DragDrop += new DragEventHandler(this.listBox_DragDrop);
            listBox.DragEnter += new DragEventHandler(this.listBox_DragEnter);
            listBox.DragEnter += new DragEventHandler(this.listBox_DragEnterColoring);
            listBox.DragLeave += new EventHandler(listBox_DragLeaveColoring);
            listBox.MouseDown += new MouseEventHandler(listBoxInstalledCerts_MouseDown);

            ListCurrentCertificates(listBox, null);
        }

        static readonly ReadOnlyCollection<string> certExtensions =
            new List<string>() { ".pfx", ".p12", ".cer" }.AsReadOnly();

        static bool IsCertificateFile(string filename)
        {
            Debug.Assert(!string.IsNullOrEmpty(filename), "!string.IsNullOrEmpty(filename)");

            foreach (string certExtension in certExtensions)
            {
                if (filename.EndsWith(certExtension))
                {
                    return true;
                }
            }
            return false;
        }

        static bool ContainsCertificateFiles(string[] filenames)
        {
            foreach (string filename in filenames)
            {
                if (IsCertificateFile(filename))
                {
                    return true;
                }
            }
            return false;
        }

        private void listBox_DragEnterColoring(object sender, DragEventArgs e)
        {
            ListBox listBox = sender as ListBox;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] names = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                if (ContainsCertificateFiles(names))
                {
                    listBox.BackColor = GetColorFromFiles(names);
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }
        }

        private static Color GetColorFromFiles(string[] files)
        {
            bool containsCerts = false;
            bool containsContainers = false;

            foreach (string file in files)
            {
                if (!containsCerts && file.EndsWith(".cer")) containsCerts = true;
                if (!containsContainers && file.EndsWith(".p12")) containsContainers = true;
                if (!containsContainers && file.EndsWith(".pfx")) containsContainers = true;

                if (containsCerts && containsContainers) break;
            }

            if (containsCerts && !containsContainers) return Color.Green;
            if (containsCerts && containsContainers) return Color.Orange;
            if (!containsCerts && containsContainers) return Color.Yellow;

            Debug.Assert(false);
            return SystemColors.Window;
        }

        void listBox_DragLeaveColoring(object sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;

            listBox.BackColor = SystemColors.Window;
        }

        private void listBox_DragEnter(object sender, DragEventArgs e)
        {
            ListBox listBox = sender as ListBox;

            CertLocation loc = listBox.Tag as CertLocation;
            // listBox.Items.Add(loc.ToString());

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] names = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                if (ContainsCertificateFiles(names))
                {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }

            e.Effect = DragDropEffects.None;
        }

        private void listBox_DragDrop(object sender, DragEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            CertLocation loc = listBox.Tag as CertLocation;

            string[] names = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string name in names)
            {
                if (IsCertificateFile(name))
                {
                    try
                    {
                        InstallCertificate(listBox, loc, name);
                    }
                    catch (CryptographicException cex)
                    {
                        MessageBox.Show(cex.Message, "Cryptography problem",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            listBox_DragLeaveColoring(sender, e);
        }

        private static void listBoxInstalledCerts_MouseDown(object sender, MouseEventArgs e)
        {
            ListBox senderListbox = sender as ListBox;
            if (senderListbox == null) return;

            int draggedIndex = senderListbox.IndexFromPoint(e.X, e.Y);
            if (draggedIndex == -1)
            {
                return;
            }
            CertLocation loc = senderListbox.Tag as CertLocation;

            List<string> exportedFilenames = new List<string>();

            string exportFolder = Path.GetTempPath(); // Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            foreach (CertData certData in senderListbox.SelectedItems)
            {
                string exportedFilename = CertificateUtilMainForm.ExportCertToFolder(certData, exportFolder, "exported");
                exportedFilenames.Add(exportedFilename);
            }

            DataObject dto = new DataObject(
                DataFormats.FileDrop, exportedFilenames.ToArray());

            senderListbox.DoDragDrop(dto, DragDropEffects.Move);
        }

        private void listBoxCertFiles_MouseDown(object sender, MouseEventArgs e)
        {
            int draggedIndex = listBoxCertFiles.IndexFromPoint(e.X, e.Y);
            if (draggedIndex == -1)
            {
                return;
            }

            string path = textBoxFolder.Text;

            List<string> filenames = new List<string>();
            foreach (string filename in listBoxCertFiles.SelectedItems)
            {
                filenames.Add(path + Path.DirectorySeparatorChar + filename);
            }
            DataObject dto = new DataObject(
                DataFormats.FileDrop, filenames.ToArray());

            listBoxCertFiles.DoDragDrop(dto, DragDropEffects.Copy);
        }

        private void InstallCertificate(ListBox listBox, CertLocation certLocation, string name)
        {
            X509Store store = null;
            try
            {
                store = new X509Store(certLocation.StoreName, certLocation.StoreLocation);
                store.Open(OpenFlags.ReadWrite);

                X509Certificate2 cert = new();
                cert.Import(name, "", X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);
                store.Add(cert);

                listBox.Items.Insert(0, new CertData(cert.RawData));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Installation problem",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (store != null)
                {
                    store.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = false;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void ListCertificates(string p)
        {
            listBoxCertFiles.Items.Clear();
            DirectoryInfo di = new DirectoryInfo(p);
            foreach (FileInfo fi in di.GetFiles())
            {
                if (IsCertificateFile(fi.FullName))
                {
                    listBoxCertFiles.Items.Add(fi.Name);
                }
            }
        }

        private void textBoxFolder_TextChanged(object sender, EventArgs e)
        {
            string potentialDir = textBoxFolder.Text;
            if (Directory.Exists(potentialDir))
            {
                ListCertificates(potentialDir);
            }
        }

        private void textBoxFilterDisplay_TextChanged(object sender, EventArgs e)
        {
            List<ListBox> listBoxes = new List<ListBox>() {
                listBoxCurrentUserMy, listBoxCurrentUserAddressBook,
                listBoxCurrentUserTrustedPeople, listBoxCurrentUserRoot,
                listBoxLocalMachineMy, listBoxLocalMachineAddressBook,
                listBoxLocalMachineTrustedPeople, listBoxLocalMachineRoot};

            #region RegEx compile

            string regexText = this.textBoxFilterDisplay.Text.Trim();
            if (regexText.Length == 0)
            {
                this.textBoxFilterDisplay.Text = ".";
                regexText = ".";
            }

            Regex regex;

            try
            {
                regex = new Regex(regexText, RegexOptions.IgnoreCase);
            }
            catch (Exception)
            {
                return;
            }

            #endregion

            foreach (ListBox listBox in listBoxes)
            {
                ListCurrentCertificates(listBox, regex);
            }
        }

        internal bool IsRegexMatch(Regex regex, X509Certificate2 cert)
        {
            return
                regex.IsMatch(cert.Subject) ||
                regex.IsMatch(cert.Issuer);
        }

        private void ListCurrentCertificates(ListBox listBox, Regex regex)
        {
            CertLocation certLocation = (CertLocation)listBox.Tag;

            listBox.Items.Clear();
            X509Store store = null;

            try
            {
                store = new X509Store(certLocation.StoreName, certLocation.StoreLocation);
                store.Open(OpenFlags.ReadOnly);

                foreach (X509Certificate2 cert in store.Certificates)
                {
                    if (regex == null ||
                        IsRegexMatch(regex, cert))
                    {
                        listBox.Items.Add(new CertData(cert.RawData));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (store != null)
                {
                    store.Close();
                }
            }
        }
    }

    internal class CertLocation
    {
        private CertLocation() { }

        public CertLocation(StoreLocation storeLocation, StoreName storeName)
        {
            this.StoreLocation = storeLocation;
            this.StoreName = storeName;
        }

        public StoreLocation StoreLocation { get; private set; }

        public StoreName StoreName { get; private set; }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "Certificate store {0}/{1}",
                Enum.GetName(typeof(StoreLocation), this.StoreLocation),
                Enum.GetName(typeof(StoreName), this.StoreName));
        }
    }
}