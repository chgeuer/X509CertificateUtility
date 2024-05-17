namespace X509CertificateTool
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Drawing;
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
            listBox.DragDrop += new DragEventHandler(this.ListBox_DragDrop);
            listBox.DragEnter += new DragEventHandler(this.ListBox_DragEnter);
            listBox.DragEnter += new DragEventHandler(this.ListBox_DragEnterColoring);
            listBox.DragLeave += new EventHandler(ListBox_DragLeaveColoring);
            listBox.MouseDown += new MouseEventHandler(ListBoxInstalledCerts_MouseDown);

            ListCurrentCertificates(listBox, null);
        }

        static readonly ReadOnlyCollection<string> certExtensions =
            new List<string>() { ".pfx", ".p12", ".cer" }.AsReadOnly();

        static bool IsCertificateFile(string filename)
        {
            Debug.Assert(!string.IsNullOrEmpty(filename), "!string.IsNullOrEmpty(filename)");

            return certExtensions.Any(filename.EndsWith);
            //foreach (string certExtension in certExtensions)
            //{
            //    if (filename.EndsWith(certExtension))
            //    {
            //        return true;
            //    }
            //}
            //return false;
        }

        static bool ContainsCertificateFiles(string[] filenames)
        {
            return filenames.Any(IsCertificateFile);
            //foreach (string filename in filenames)
            //{
            //    if (IsCertificateFile(filename))
            //    {
            //        return true;
            //    }
            //}
            //return false;
        }

        private void ListBox_DragEnterColoring(object sender, DragEventArgs e)
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

        void ListBox_DragLeaveColoring(object sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;

            listBox.BackColor = SystemColors.Window;
        }

        private void ListBox_DragEnter(object sender, DragEventArgs e)
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

        private void ListBox_DragDrop(object sender, DragEventArgs e)
        {
            ListBox listBox = (ListBox) sender;
            CertLocation loc = (CertLocation) listBox.Tag;

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

            ListBox_DragLeaveColoring(sender, e);
        }

        private static void ListBoxInstalledCerts_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is not ListBox senderListbox) return;

            int draggedIndex = senderListbox.IndexFromPoint(e.X, e.Y);
            if (draggedIndex == -1)
            {
                return;
            }

            _ = senderListbox.Tag as CertLocation;

            List<string> exportedFilenames = [];

            string exportFolder = Path.GetTempPath(); // Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            foreach (CertData certData in senderListbox.SelectedItems)
            {
                string exportedFilename = CertificateUtilMainForm.ExportCertToFolder(certData, exportFolder, "exported");
                exportedFilenames.Add(exportedFilename);
            }

            DataObject dto = new(DataFormats.FileDrop, exportedFilenames.ToArray());

            senderListbox.DoDragDrop(dto, DragDropEffects.Move);
        }

        private void ListBoxCertFiles_MouseDown(object sender, MouseEventArgs e)
        {
            int draggedIndex = listBoxCertFiles.IndexFromPoint(e.X, e.Y);
            if (draggedIndex == -1)
            {
                return;
            }

            string path = textBoxFolder.Text;

            List<string> filenames = [];
            foreach (string filename in listBoxCertFiles.SelectedItems)
            {
                filenames.Add(path + Path.DirectorySeparatorChar + filename);
            }
            DataObject dto = new(DataFormats.FileDrop, filenames.ToArray());

            listBoxCertFiles.DoDragDrop(dto, DragDropEffects.Copy);
        }

        private static void InstallCertificate(ListBox listBox, CertLocation certLocation, string name)
        {
            X509Store store = null;
            try
            {
                store = new X509Store(certLocation.StoreName, certLocation.StoreLocation);
                store.Open(OpenFlags.ReadWrite);

                using X509Certificate2 cert = new();         // TODO

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
                store?.Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
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

        private void TextBoxFolder_TextChanged(object sender, EventArgs e)
        {
            string potentialDir = textBoxFolder.Text;
            if (Directory.Exists(potentialDir))
            {
                ListCertificates(potentialDir);
            }
        }

        private void TextBoxFilterDisplay_TextChanged(object sender, EventArgs e)
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
                store?.Close();
            }
        }
    }

    internal record CertLocation
    {
        public readonly StoreLocation StoreLocation;

        public readonly StoreName StoreName;

        public CertLocation(StoreLocation storeLocation, StoreName storeName) => (StoreLocation, StoreName) = (storeLocation, storeName);

        public override string ToString()
        {
            return $"Certificate store {Enum.GetName(typeof(StoreLocation), this.StoreLocation)}/{Enum.GetName(typeof(StoreName), this.StoreName)}";
        }
    }
}