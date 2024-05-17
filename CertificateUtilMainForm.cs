namespace X509CertificateTool;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

public partial class CertificateUtilMainForm : Form
{
    #region Constructors

    static CertificateUtilMainForm()
    {
        StoreName[] asn = {
            StoreName.My,
            StoreName.Root,
            StoreName.AddressBook,
            StoreName.AuthRoot,
            StoreName.CertificateAuthority,
            StoreName.Disallowed,
            StoreName.TrustedPeople,
            StoreName.TrustedPublisher };
        CertificateUtilMainForm._allStoreNames.AddRange(asn);

        StoreLocation[] asl = {
            StoreLocation.CurrentUser,
            StoreLocation.LocalMachine };
        CertificateUtilMainForm._allStoreLocations.AddRange(asl);
    }

    public CertificateUtilMainForm()
    {
        InitializeComponent();

        this._selectedStoreLocations.Clear();
        this._selectedStoreLocations.AddRange(CertificateUtilMainForm._allStoreLocations);

        this._selectedStoreNames.Clear();
        this._selectedStoreNames.AddRange(CertificateUtilMainForm._allStoreNames);

        this.contextMenuStrip.Items[0].Text = String.Format("Give user {0} read-access to the private key", ASPNETUser);
        this.textBoxRegex.Text = Regex;
    }

    #endregion

    #region Search storeLocation management

    internal static readonly List<StoreName> _allStoreNames = [];
    internal static readonly List<StoreLocation> _allStoreLocations = [];

    List<StoreName> _selectedStoreNames = [];
    IList<StoreName> StoreNamesToSearch
    {
        get
        {
            return _selectedStoreNames;
        }
    }

    List<StoreLocation> _selectedStoreLocations = [];
    IList<StoreLocation> StoreLocationsToSearch
    {
        get
        {
            return _selectedStoreLocations;
        }
    }

    #endregion

    #region Search algorithms

    private static bool RegexMatchCase
    {
        get { return Properties.Settings.Default.regexMatchCase; }
        set
        {
            Properties.Settings.Default.regexMatchCase = value;
            Properties.Settings.Default.Save();
        }
    }

    private static string Regex
    {
        get { return Properties.Settings.Default.regex; }
        set
        {
            Properties.Settings.Default.regex = value;
            Properties.Settings.Default.Save();
        }
    }

    private Collection<CertData> searchByRegex(
        StoreLocation storeLocation, StoreName storeName, Regex regex)
    {
        Collection<CertData> result = [];

        Collection<CertData> allCertsInStore = Cache.GetCachedData(
            storeLocation, storeName.ToString(),
            false, false);
        foreach (CertData certData in allCertsInStore)
        {
            if (certData.IsRegexMatch(regex))
            {
                result.Add(certData);
            }
        }

        return result;
    }

    private static ICollection<CertData> searchByKeyIdentifier(
        StoreLocation storeLocation, StoreName storeName, string keyIdentifier)
    {
        Collection<CertData> result = [];

        Collection<CertData> allCertsInStore = Cache.GetCachedData(
            storeLocation, storeName.ToString(),
            computeKeyIdentifiersImmediately: true,
            computePrivateKeyDataImmediately: false);

        if (keyIdentifier.Contains("RSAKeyValue"))
        {
            foreach (CertData certData in allCertsInStore)
            {
                if (certData.EqualsPublicKey(keyIdentifier))
                {
                    result.Add(certData);
                }
            }
        }
        else
        {
            foreach (CertData certData in allCertsInStore)
            {
                if (certData.EqualsKeyIdentifier(keyIdentifier))
                {
                    result.Add(certData);
                }
            }
        }

        return result;
    }

    #endregion

    #region UI Code

    private void showSearchOptions(object sender, EventArgs e)
    {
        StoreSelectionForm ssf = new(_allStoreLocations, _allStoreNames, _selectedStoreLocations, _selectedStoreNames, RegexMatchCase);

        ssf.ShowDialog();

        _selectedStoreLocations.Clear();
        _selectedStoreLocations.AddRange(ssf.StoreLocations);

        _selectedStoreNames.Clear();
        _selectedStoreNames.AddRange(ssf.StoreNames);

        RegexMatchCase = ssf.RegexMatchCase;
    }

    private void buttonRegexGo_Click(object sender, EventArgs e)
    {
        this.ClearUI(ClearCertificateList.Yes);

        // clear the other TextBox
        this.textBoxCryptoValue.Clear();
        this.buttonValueGo.Enabled = false;

        string regexText = this.textBoxRegex.Text.Trim();
        if (regexText.Length == 0)
        {
            this.textBoxRegex.Text = ".";
            regexText = ".";
        }

        Regex = regexText;

        Regex regex;
        RegexOptions regexOptions = RegexMatchCase ?
            RegexOptions.None : RegexOptions.IgnoreCase;

        try
        {
            regex = new Regex(regexText, regexOptions);
        }
        catch (Exception ex)
        {
            errorProviderRegexTextbox.SetError(buttonRegexGo, ex.Message);
            return;
        }
        errorProviderRegexTextbox.Clear();

        Cursor oldCursor = base.Cursor;
        base.Cursor = Cursors.WaitCursor;
        foreach (StoreLocation storeLocation in StoreLocationsToSearch)
        {
            foreach (StoreName storeName in StoreNamesToSearch)
            {
                ICollection<CertData> certDataCollection = this.searchByRegex(
                    storeLocation, storeName, regex);

                AddCertsToList(certDataCollection);
            }
        }
        Cursor = oldCursor;

        this.buttonValueGo.Enabled = true;

        SelectAndShowFirstCert();
    }

    private void buttonValueGo_Click(object sender, EventArgs e)
    {
        this.ClearUI(ClearCertificateList.Yes);
        // clear the other TextBox
        this.textBoxRegex.Clear();
        this.buttonRegexGo.Enabled = false;

        string searchValue = this.textBoxCryptoValue.Text.Trim();
        if (searchValue.Length == 0)
        {
            return;
        }

        Cursor oldCursor = base.Cursor;
        base.Cursor = Cursors.WaitCursor;

        if (searchValue.Contains("RSAKeyValue") == false)
        {
            try
            {
                // check whether the search value is a hex encoded public key
                byte[] csp = FromHex(searchValue);
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.ImportCspBlob(csp);
                var value = new System.Security.Cryptography.Xml.RSAKeyValue(rsa);
                var xml = value.GetXml();
                string publicKeyXml = xml.InnerXml;

                if (publicKeyXml.Contains("RSAKeyValue"))
                {
                    searchValue = publicKeyXml;
                }
            }
            catch
            {
            }
        }

        foreach (StoreLocation storeLocation in StoreLocationsToSearch)
        {
            foreach (StoreName storeName in StoreNamesToSearch)
            {
                ICollection<CertData> certCollection = searchByKeyIdentifier(storeLocation, storeName,
                    searchValue);

                AddCertsToList(certCollection);
            }
        }
        Cursor = oldCursor;

        this.buttonRegexGo.Enabled = true;
        SelectAndShowFirstCert();
    }

    private void textBoxCryptoValue_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.V)
        {
            string c = Clipboard.GetText();
            if (c != null && c.Contains("RSAKeyValue"))
            {
                Clipboard.SetText(SimpleRSAPubKey.CanonicalizeKey(c));
            }

            e.Handled = true;
            return;
        }
        if (e.KeyCode == Keys.Return)
        {
            buttonValueGo_Click(sender, e);
            e.Handled = true;
        }
        this.textBoxRegex.Clear();
    }

    private void textBoxRegex_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Return)
        {
            buttonRegexGo_Click(sender, e);
            e.Handled = true;
        }
        this.textBoxCryptoValue.Clear();
    }

    private void textBoxRegex_Enter(object sender, EventArgs e)
    {
        this.buttonRegexGo.Enabled = true;
        this.buttonValueGo.Enabled = false;
    }

    private void textBoxCryptoValue_Enter(object sender, EventArgs e)
    {
        this.buttonRegexGo.Enabled = false;
        this.buttonValueGo.Enabled = true;
    }

    #region Drag&Drop

    //private static bool isBase64Encoded(string value)
    //{
    //    try
    //    {
    //        byte[] octets = Convert.FromBase64String(value);
    //        return octets != null && octets.Length != 0;
    //    }
    //    catch (Exception)
    //    {
    //        return false;
    //    }
    //}
    //
    //private void hookupDragDrop()
    //{
    //    this.textBoxCryptoValue.AllowDrop = true;
    //    this.textBoxCryptoValue.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxCryptoValue_DragDrop);
    //    this.textBoxCryptoValue.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxCryptoValue_DragEnter);
    //}
    //
    //private static bool isHexString(string value)
    //{
    //    return Regex.IsMatch(value, @"\A[abcdefABCDEF\d]+\Z");
    //}
    //
    //private static bool isCryptoValue(string value)
    //{
    //    return isHexString(value) && isBase64Encoded(value);
    //}
    //
    //private void textBoxCryptoValue_DragEnter(object sender, DragEventArgs e)
    //{
    //    if (e.Data.GetDataPresent(typeof(string)))
    //    {
    //        string dragData = (string)e.Data.GetData(typeof(string));
    //        if (isCryptoValue(dragData))
    //        {
    //            e.Effect = DragDropEffects.Copy;
    //        }
    //    }
    //
    //    e.Effect = DragDropEffects.None;
    //}
    //
    //private void textBoxCryptoValue_DragDrop(object sender, DragEventArgs e)
    //{
    //    string dragData = (string)e.Data.GetData(typeof(string));
    //    this.textBoxCryptoValue.Text = dragData;
    //}

    #endregion

    private void NewCertificateSelected(object sender, EventArgs e)
    {
        var certData = GetSelectedCertWrapperForListBox();

        FillUI(certData);
    }

    private void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
    {
        var selectedCerts = GetSelectedCertWrapperForListBox();
        if (selectedCerts.Count == 0)
        {
            e.Cancel = true;
        }
        else if (selectedCerts.Count == 1)
        {
            CertData certData = selectedCerts[0];

            giveASPNETReadonlyAccessOnThePrivateKeyToolStripMenuItem.Enabled = (certData.StoreLocation == StoreLocation.LocalMachine);
            exportCertificateAsPKCS12ContainerToolStripMenuItem.Enabled = certData.CertHasPrivateKey;
        }
        else
        {
            giveASPNETReadonlyAccessOnThePrivateKeyToolStripMenuItem.Enabled = false;
            exportCertificateAsPKCS12ContainerToolStripMenuItem.Enabled = false;
        }
    }

    private void DisplayCertificateUI(object sender, EventArgs e)
    {
        var selectedCerts = GetSelectedCertWrapperForListBox();
        if (selectedCerts.Count == 1)
        {
            FillUI(selectedCerts);

            X509Certificate2 cert = selectedCerts[0].GetX509Certificate2ClientWillCallReset();
            X509Certificate2UI.DisplayCertificate(cert);
            cert.Reset();
        }
    }

    private static ListViewItem CreateListViewItem(CertData certData)
    {
        string storeLocation;
        string storeName;

        if (certData.m_transientCert != null)
        {
            storeLocation = "";
            storeName = "";
        }
        else
        {
            storeLocation = certData.StoreLocation.ToString();
            storeName = certData.StoreNameAsString;
        }

        ListViewItem item = new(storeLocation)
        {
            Tag = certData
        };
        item.SubItems.Add(storeName);
        item.SubItems.Add(certData.CertSubject);
        item.SubItems.Add(certData.CertIssuer);

        return item;
    }

    private void ButtonViewCertificateInClipboardClicked(object sender, EventArgs e)
    {
        string c = Clipboard.GetText();
        if (string.IsNullOrEmpty(c))
        {
            return;
        }

        CertData certData = null;

        try
        {
            // try to parse the clipboard content as base64
            byte[] certRawData = Convert.FromBase64String(c);
            certData = new CertData(certRawData);
        }
        catch
        {
            try
            {
                // try to parse the clipboard content as base64
                byte[] certRawData = FromHex(c);
                certData = new CertData(certRawData);
            }
            catch
            {
            }
        }

        if (certData != null)
        {
            listViewCertificates.Items.Clear();
            listViewCertificates.Items.Add(CreateListViewItem(certData));

            this.FillUI(new List<CertData>() { certData });
        }
        else
        {
            MessageBox.Show("The clipboard does not contain a base64 or hex encoded certificate!", "Invalid clipboard content", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void DisplayPrivateKeyFileProperties(object sender, EventArgs e)
    {
        if (textBoxPrivateKeyFilename.Text.Length > 0)
        {
            FileInfo fi = new FileInfo(textBoxPrivateKeyFilename.Text);
            if (fi.Exists)
            {
                CertificateDialog.ShowFilePropertiesDialog(Handle, fi.DirectoryName, fi.Name);
            }
        }
    }

    private void ButtonClearCachedCerts_Click(object sender, EventArgs e)
    {
        Cache.Clear();
    }

    void SelectAndShowFirstCert()
    {
        if (this.listViewCertificates.Items.Count > 0)
        {
            SelectListViewItem(0);
            this.listViewCertificates.Focus();
        }
    }

    private void ClearUI(ClearCertificateList clearCertificateListBox)
    {
        this.textBoxCertIssuer.Clear();
        this.textBoxKeyIdentifierCAPI.Clear();
        this.textBoxKeyIdentifierIssuerSerial.Clear();
        this.textBoxKeyIdentifierRFC3280.Clear();
        this.textBoxKeyIdentifierThumbprintSHA1.Clear();
        this.textBoxStoreLocation.Clear();
        this.textBoxStoreName.Clear();
        this.textBoxCertSubject.Clear();
        this.textBoxCertSubject.BackColor = Color.White;
        this.textBoxValidity.Clear();
        this.textBoxValidity.BackColor = Color.White;
        this.textBoxPrivateKeyFilename.Clear();
        this.textBoxCertSerialNumber.Clear();
        this.textBoxCertThumbprint.Clear();

        if (clearCertificateListBox == ClearCertificateList.Yes)
        {
            this.listViewCertificates.Items.Clear();
        }
    }

    private void FillUI(List<CertData> certDataItems)
    {
        if (certDataItems.Count == 0)
        {
            ClearUI(ClearCertificateList.No);
            return;
        }

        Cursor oldCursor = base.Cursor;
        base.Cursor = Cursors.WaitCursor;

        if (certDataItems.Count == 1)
        {
            #region Display data of a single cert in UI

            CertData certData = certDataItems[0];
            bool isLocalMachine = certData.StoreLocation == StoreLocation.LocalMachine;

            this.buttonASPNET.Enabled = isLocalMachine;
            this.buttonViewCertificate.Enabled = true;
            this.buttonShowPrivateKeyFileProperties.Enabled = true;

            this.textBoxStoreLocation.Text = certData.StoreLocation.ToString();
            this.textBoxStoreName.Text = certData.StoreNameAsString;

            this.textBoxCertIssuer.Text = certData.CertIssuer;
            this.textBoxCertSubject.Text = certData.CertSubject;
            this.textBoxCertThumbprint.Text = certData.CertThumbprint;
            this.textBoxCertSerialNumber.Text = certData.CertSerialNumber;

            #region Time validity

            this.textBoxValidity.Text = certData.CertNotBefore.ToLocalTime().ToString() + " --> " + certData.CertNotAfter.ToLocalTime().ToString();
            if (certData.CertNotBefore.ToLocalTime().CompareTo(DateTime.Now) <= 0 &&
                DateTime.Now.CompareTo(certData.CertNotAfter.ToLocalTime()) <= 0)
            {
                this.textBoxValidity.BackColor = Color.LightGreen;
            }
            else
            {
                this.textBoxValidity.BackColor = Color.Red;
            }

            #endregion

            this.textBoxKeyIdentifierCAPI.Text = certData.KeyIdentifierCAPI;
            this.textBoxKeyIdentifierRFC3280.Text = certData.KeyIdentifierRFC3280;
            this.textBoxKeyIdentifierIssuerSerial.Text = certData.KeyIdentifierIssuerSerial;
            this.textBoxKeyIdentifierThumbprintSHA1.Text = certData.KeyIdentifierThumbprintSHA1;

            this.textBoxCertSubject.BackColor = (certData.CertHasPrivateKey ? Color.LightGreen : Color.LightGray);
            this.textBoxPrivateKeyFilename.Text = certData.PrivateKeyFileName;

            // Display labels
            this.labelDisplayCertIsCACert.Visible = certData.ExtensionIsCACert;
            this.labelDisplayPrivateKeyIsExportable.Visible = certData.PrivateKeyIsExportable;
            this.labelDisplayCertHasPrivateKey.Visible = certData.CertHasPrivateKey;

            bool onlyIssuerSerial = certData.OnlyIssuerSerialIsDefined;
            this.labelKeyIdentifierIssuerSerial.Enabled = onlyIssuerSerial;
            this.textBoxKeyIdentifierIssuerSerial.Visible = onlyIssuerSerial;

            this.labelKeyIdentifierThumbprintSHA1.Enabled = !onlyIssuerSerial;
            this.textBoxKeyIdentifierThumbprintSHA1.Visible = !onlyIssuerSerial;
            this.labelKeyIdentifierCAPI.Enabled = !onlyIssuerSerial;
            this.textBoxKeyIdentifierCAPI.Visible = !onlyIssuerSerial;
            this.labelKeyIdentifierRFC3280.Enabled = !onlyIssuerSerial;
            this.textBoxKeyIdentifierRFC3280.Visible = !onlyIssuerSerial;

            #endregion
        }
        else
        {
            #region there are multiple selections, so we cannot display sensible details

            foreach (var tb in new[] { textBoxStoreLocation, textBoxStoreName, textBoxCertIssuer,
                textBoxCertSubject, textBoxCertThumbprint, textBoxCertSerialNumber, textBoxValidity,
                textBoxKeyIdentifierRFC3280, textBoxKeyIdentifierThumbprintSHA1, textBoxKeyIdentifierCAPI,
                textBoxKeyIdentifierIssuerSerial, textBoxPrivateKeyFilename })
            {
                tb.Clear();
            }

            foreach (var lbl in new[] { labelDisplayCertIsCACert, labelDisplayPrivateKeyIsExportable,
                labelDisplayCertHasPrivateKey})
            {
                lbl.Visible = false;
            }

            foreach (var btn in new[] { buttonASPNET, buttonViewCertificate, buttonShowPrivateKeyFileProperties })
            {
                btn.Enabled = false;
            }

            #endregion
        }

        Cursor = oldCursor;
    }

    private void AddCertsToList(ICollection<CertData> certs)
    {
        if (certs != null)
        {
            listViewCertificates.BeginUpdate();

            certs.ToList().ForEach(cert =>
                listViewCertificates.Items.Add(CreateListViewItem(cert)));

            AutoResize(listViewCertificates);

            listViewCertificates.EndUpdate();
        }
    }

    #region ListView Helper

    private void SelectListViewItem(int index)
    {
        for (int i = 0; i < this.listViewCertificates.Items.Count; i++)
        {
            this.listViewCertificates.Items[i].Selected = (i == index);
        }
    }

    private List<CertData> GetSelectedCertWrapperForListBox()
    {
        List<CertData> certData = new List<CertData>();

        for (int i = 0; i < this.listViewCertificates.SelectedItems.Count; i++)
        {
            certData.Add(this.listViewCertificates.SelectedItems[i].Tag as CertData);
        }

        return certData;
    }

    public static void AutoResize(ListView listView)
    {
        if (listView != null)
        {
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            if (listView.Columns != null)
            {
                foreach (ColumnHeader header in listView.Columns)
                {
                    if (header != null)
                    {
                        int headerWidth = header.Width;
                        header.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                        int contenWidth = header.Width;

                        if (contenWidth < headerWidth)
                        {
                            header.Width = headerWidth;
                        }
                    }
                }
            }
        }
    }

    class ListViewItemComparer : System.Collections.IComparer
    {
        private enum ColumnIndex { Location = 0, Name, Subject, Issuer, LastIndex }; // these must match the DisplayIndex values of the ListView column headers
        private ColumnIndex _ColumnIndex;

        public ListViewItemComparer()
        {
            _ColumnIndex = ColumnIndex.Location;
        }

        public ListViewItemComparer(int column)
        {
            _ColumnIndex = (ColumnIndex)column;
        }

        public int Compare(object x, object y)
        {
            int result = 0;

            if (x is ListViewItem item1 &&
                y is ListViewItem item2 &&
                item1.SubItems.Count >= (int)ColumnIndex.LastIndex &&
                item2.SubItems.Count >= (int)ColumnIndex.LastIndex)
            {
                switch (_ColumnIndex)
                {
                    case ColumnIndex.Location:
                        {
                            result = CompareLocation(item1, item2);
                            if (result == 0)
                            {
                                result = CompareName(item1, item2);
                                if (result == 0)
                                {
                                    result = CompareSubject(item1, item2);
                                    if (result == 0)
                                    {
                                        result = CompareIssuer(item1, item2);
                                    }
                                }
                            }
                            break;
                        }
                    case ColumnIndex.Name:
                        {
                            result = CompareName(item1, item2);
                            if (result == 0)
                            {
                                result = CompareLocation(item1, item2);
                                if (result == 0)
                                {
                                    result = CompareSubject(item1, item2);
                                    if (result == 0)
                                    {
                                        result = CompareIssuer(item1, item2);
                                    }
                                }
                            }
                            break;
                        }
                    case ColumnIndex.Subject:
                        {
                            result = CompareSubject(item1, item2);
                            if (result == 0)
                            {
                                result = CompareLocation(item1, item2);
                                if (result == 0)
                                {
                                    result = CompareName(item1, item2);
                                    if (result == 0)
                                    {
                                        result = CompareIssuer(item1, item2);
                                    }
                                }
                            }
                            break;
                        }
                    case ColumnIndex.Issuer:
                        {
                            result = CompareIssuer(item1, item2);
                            if (result == 0)
                            {
                                result = CompareSubject(item1, item2);
                                if (result == 0)
                                {
                                    result = CompareLocation(item1, item2);
                                    if (result == 0)
                                    {
                                        result = CompareName(item1, item2);
                                    }
                                }
                            }
                            break;
                        }
                    default:
                        break;
                }
            }

            return result;
        }

        private int CompareLocation(ListViewItem x, ListViewItem y)
        {
            //return String.Compare(x.SubItems[(int)ColumnIndex.Location].Text, y.SubItems[(int)ColumnIndex.Location].Text);
            int ix = GetIndex(CertificateUtilMainForm._allStoreLocations, x.SubItems[(int)ColumnIndex.Location].Text);
            int iy = GetIndex(CertificateUtilMainForm._allStoreLocations, y.SubItems[(int)ColumnIndex.Location].Text);
            return ix.CompareTo(iy);
        }

        private int CompareName(ListViewItem x, ListViewItem y)
        {
            //return String.Compare(x.SubItems[(int)ColumnIndex.Name].Text, y.SubItems[(int)ColumnIndex.Name].Text);
            int ix = GetIndex(CertificateUtilMainForm._allStoreNames, x.SubItems[(int)ColumnIndex.Name].Text);
            int iy = GetIndex(CertificateUtilMainForm._allStoreNames, y.SubItems[(int)ColumnIndex.Name].Text);
            return ix.CompareTo(iy);
        }

        private int CompareSubject(ListViewItem x, ListViewItem y)
        {
            return String.Compare(x.SubItems[(int)ColumnIndex.Subject].Text, y.SubItems[(int)ColumnIndex.Subject].Text);
        }

        private int CompareIssuer(ListViewItem x, ListViewItem y)
        {
            return String.Compare(x.SubItems[(int)ColumnIndex.Issuer].Text, y.SubItems[(int)ColumnIndex.Issuer].Text);
        }

        private static int GetIndex(List<StoreLocation> storeLocations, string storeLocation)
        {
            try
            {
                return storeLocations.IndexOf((StoreLocation)Enum.Parse(typeof(StoreLocation), storeLocation));
            }
            catch
            {
                return -1;
            }
        }

        private int GetIndex(List<StoreName> storeNames, string storeName)
        {
            try
            {
                return storeNames.IndexOf((StoreName)Enum.Parse(typeof(StoreName), storeName));
            }
            catch
            {
                return -1;
            }
        }
    }

    #endregion

    #endregion

    private void CopyPublicKeyToClipboard(object sender, EventArgs e)
    {
        var selectedCerts = GetSelectedCertWrapperForListBox();
        if (selectedCerts.Count != 1)
        {
            return;
        }

        Clipboard.SetText(selectedCerts[0].PublicKey.ToString());
    }

    private void CopyAsWCFCfg_FindBySubjectDistinguishedName(object sender, EventArgs e)
    {
        this.CopyAsWCFCfg(
            X509FindType.FindBySubjectDistinguishedName,
            delegate(CertData certData) { return certData.CertSubject; });
    }

    private void CopyAsWCFCfg_FindByThumbprint(object sender, EventArgs e)
    {
        this.CopyAsWCFCfg(
            X509FindType.FindByThumbprint,
            delegate(CertData certData) { return certData.CertThumbprint; });
    }

    private delegate string ExtractData(CertData certData);

    private void CopyAsWCFCfg(X509FindType findType, ExtractData extractor)
    {
        var selectedCerts = GetSelectedCertWrapperForListBox();
        if (selectedCerts.Count != 1)
        {
            return;
        }

        CertData certData = selectedCerts[0];
        if (certData == null)
        {
            return;
        }

        string findValue = extractor(certData);
        string storeLocation = Enum.GetName(typeof(StoreLocation), certData.StoreLocation);
        string storeName = certData.StoreNameAsString;
        string x509FindType = Enum.GetName(typeof(X509FindType), findType);

        string separator = "\n ";
        string wcfConfigAttributes = string.Format(
            " findValue=\"{0}\"{4}storeLocation=\"{1}\"{4}storeName=\"{2}\"{4}x509FindType=\"{3}\"{4}",
            findValue, storeLocation, storeName, x509FindType, separator);

        Clipboard.SetText(wcfConfigAttributes);
    }

    private void copyEncodedCertificateToClipboard(object sender, EventArgs e)
    {
        var selectedCerts = GetSelectedCertWrapperForListBox();
        if (selectedCerts.Count != 1)
        {
            return;
        }

        X509Certificate2 cert = null;
        try
        {
            cert = selectedCerts[0].GetX509Certificate2ClientWillCallReset();

            // call Thumbprint to potentially update cert
            string ignore = cert.Thumbprint;

            byte[] certOctets = cert.Export(X509ContentType.Cert);
            string encodedCertificate = Convert.ToBase64String(certOctets);

            Clipboard.SetText(encodedCertificate);
        }
        finally
        {
            if (cert != null)
            {
                cert.Reset();
            }
        }
    }

    private void copyEncodedPKCS12CertificateToClipboard(object sender, EventArgs e)
    {
        var selectedCerts = GetSelectedCertWrapperForListBox();
        if (selectedCerts.Count != 1)
        {
            return;
        }

        X509Certificate2 cert = null;
        try
        {
            cert = selectedCerts[0].GetX509Certificate2ClientWillCallReset();

            // call Thumbprint to potentially update cert
            string ignore = cert.Thumbprint;

            PfxPasswordDialog passDlg = new PfxPasswordDialog();
            if (passDlg.ShowDialog() == DialogResult.OK)
            {
                byte[] certOctets = cert.Export(X509ContentType.Pkcs12, passDlg.Password);
                string encodedCertificate = Convert.ToBase64String(certOctets);

                Clipboard.SetText(encodedCertificate);
            }
        }
        finally
        {
            if (cert != null)
            {
                cert.Reset();
            }
        }
    }

    private static string ExportFilenameSuggestionForCertificate(X509Certificate2 cert)
    {
        string s = cert.Subject
            .Replace("=", "_")
            .Replace("://", "_")
            .Replace("/", "_")
            .Replace(":", "_")
            .Replace("\"", "_")
            .Replace("*", "_");

        while (s.Contains("__"))
        {
            s = s.Replace("__", "_");
        }

        return s;
    }

    private void listBox_MouseDown(object sender, MouseEventArgs e)
    {
        // StartDragDrop();
    }

    private void StartDragDrop()
    {
        List<string> exportedFilenames = new List<string>();

        string exportFolder = Path.GetTempPath(); // Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        foreach (var certData in GetSelectedCertWrapperForListBox())
        {
            string exportedFilename = CertificateUtilMainForm.ExportCertToFolder(certData,
                exportFolder, "exported");
            exportedFilenames.Add(exportedFilename);
        }

        DataObject dto = new DataObject(
            DataFormats.FileDrop, exportedFilenames.ToArray());

        listViewCertificates.DoDragDrop(dto, DragDropEffects.Move);
    }

    private void exportCertificateAsPKCS12Container(object sender, EventArgs e)
    {
        var selectedCerts = GetSelectedCertWrapperForListBox();
        if (selectedCerts.Count != 1)
        {
            MessageBox.Show("Could not retrieve certificate to export", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        CertData certData = selectedCerts[0];

        X509Certificate2 cert = null;
        try
        {
            cert = certData.GetX509Certificate2ClientWillCallReset();

            saveFileDialogPkcs12Export.FileName = ExportFilenameSuggestionForCertificate(cert);

            if (saveFileDialogPkcs12Export.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialogPkcs12Export.FileName;
                PfxPasswordDialog passDlg = new PfxPasswordDialog();
                if (passDlg.ShowDialog() == DialogResult.OK)
                {
                    byte[] certOctets = cert.Export(X509ContentType.Pkcs12, passDlg.Password);
                    FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
                    fs.Write(certOctets, 0, certOctets.Length);
                    fs.Close();

                    MessageBox.Show(string.Format(CultureInfo.CurrentCulture,
                        "Certificate {0} successfully exported to file {1}", cert.Subject, filename),
                        "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(string.Format("Could not export certificate to export: {0}",
                ex.Message), "Export error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            if (cert != null)
            {
                cert.Reset();
            }
        }
    }

    private void exportCertificateAsRegularCertificate(object sender, EventArgs e)
    {
        var selectedCerts = GetSelectedCertWrapperForListBox();
        if (selectedCerts.Count == 0)
        {
            MessageBox.Show("Could not retrieve certificate to export", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        CertData certData = selectedCerts[0];
        X509Certificate2 cert = null;
        try
        {
            cert = certData.GetX509Certificate2ClientWillCallReset();

            // call Thumbprint to potentially update cert
            string ignore = cert.Thumbprint;

            saveFileDialogCertificateExport.FileName = ExportFilenameSuggestionForCertificate(cert);

            if (saveFileDialogCertificateExport.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialogCertificateExport.FileName;

                byte[] certOctets = cert.Export(X509ContentType.Cert);
                FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
                fs.Write(certOctets, 0, certOctets.Length);
                fs.Close();

                MessageBox.Show(string.Format("Certificate {0} successfully exported to file {1}",
                    cert.Subject, filename), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(string.Format("Could not export certificate to export: {0}",
                ex.Message), "Export error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            if (cert != null)
            {
                cert.Reset();
            }
        }
    }

    private void ExportCertificatesIntoDeveloperContainer(object sender, EventArgs e)
    {
        var selectedCerts = GetSelectedCertWrapperForListBox();

        if (selectedCerts.Count == 0)
            return;

        var dlg = new SaveFileDialog()
        {
            AddExtension = true,
            DefaultExt = ".certbatch",
            Filter = "Certificate batch files|*.certbatch|All files|*.*"
        };
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            BatchCertificateContainer container = new BatchCertificateContainer(dlg.FileName,
                selectedCerts);
            container.Store();
        }
    }

    private void InstallCertificatesFromDeveloperContainer(object sender, EventArgs e)
    {
        var dlg = new OpenFileDialog()
        {
            DefaultExt = ".certbatch",
            Filter = "Certificate batch files|*.certbatch|All files|*.*"
        };
        if (dlg.ShowDialog() == DialogResult.OK)
        {

            BatchCertificateContainer c2 = new BatchCertificateContainer(dlg.FileName);
            c2.Install(certData => true);
        }
    }

    private void buttonInstallCerts_Click(object sender, EventArgs e)
    {
        CertificateInstallationForm f = new CertificateInstallationForm();
        f.Show();
    }

    #region Grant private key access

    private void grantAspnetReadAccess(object sender, EventArgs e)
    {
        var selectedCerts = GetSelectedCertWrapperForListBox();
        if (selectedCerts.Count == 0)
        {
            return;
        }

        CertData certData = selectedCerts[0];

        if (certData != null)
        {
            FileInfo keyFileInfo = new FileInfo(certData.PrivateKeyFileName);
            if (!keyFileInfo.Exists)
            {
                MessageBox.Show("File does not exist");
                return;
            }

            string username = ASPNETUser;

            FileGrantReadAccess(keyFileInfo, username);

            MessageBox.Show(String.Format("Granted {0} read access on certificate {1}",
                username, certData.CertSubject));
        }
    }

    private static void FileGrantReadAccess(FileInfo keyFileInfo, string username)
    {
        FileSecurity fileSecurity = keyFileInfo.GetAccessControl();

        FileSystemAccessRule readAccess = new FileSystemAccessRule(
            username,
            FileSystemRights.Read,
            AccessControlType.Allow);

        fileSecurity.AddAccessRule(readAccess);

        keyFileInfo.SetAccessControl(fileSecurity);
    }

    string ASPNETUser
    {
        get
        {
            int major = System.Environment.OSVersion.Version.Major;
            int minor = System.Environment.OSVersion.Version.Minor;

            const string defaultStr = "ASPNET";

            switch (major)
            {
                case 3:
                    // Windows NT 3.51
                    return defaultStr;
                case 4:
                    // Windows NT 4.0
                    return defaultStr;
                case 5:
                    switch (minor)
                    {
                        case 0:
                            // Windows 2000
                            return defaultStr;
                        case 1:
                            // Windows XP
                            return "ASPNET";
                        case 2:
                            // Windows Server 2003
                            return "NETWORK SERVICE";
                        default:
                            return defaultStr;
                    }
                case 6:
                    // Vista
                    return "NETWORKSERVICE";
                default:
                    return defaultStr;
            }
        }
    }

    void listViewCertificates_ColumnClick(object sender, ColumnClickEventArgs e)
    {
        this.listViewCertificates.ListViewItemSorter = new ListViewItemComparer(e.Column);
    }

    #endregion

    #region Delete certificates

    internal enum DeleteResult
    {
        Deleted,
        Cancelled
    }

    private void ListViewCertificates_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Delete)
        {
            return;
        }

        if (!checkBoxAllowCertDeletion.Checked)
        {
            return;
        }

        var selectedCerts = GetSelectedCertWrapperForListBox();
        if (selectedCerts.Count == 0)
        {
            return;
        }

        CertData certData = selectedCerts[0];

        if (certData.CertHasPrivateKey && !certData.PrivateKeyIsExportable)
        {
            MessageBox.Show("Refuse to delete this certificate, because it has a private key which cannot be backed-up");

            return;
        }

        string folder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        if (DeleteResult.Deleted == exportCertificateAsPKCS12ContainerIntoFolderAndDelete(
            certData, folder, checkBoxNoDeletionPrompt.Checked))
        {
            int idx = listViewCertificates.SelectedIndices[0];
            listViewCertificates.Items.RemoveAt(idx);

            // reposition selection
            listViewCertificates.SelectedIndices.Clear();
            if (idx >= listViewCertificates.Items.Count)
            {
                idx = listViewCertificates.Items.Count - 1;
            }
            if (idx >= 0)
            {
                listViewCertificates.SelectedIndices.Add(idx);
            }
        }
    }

    internal static string ExportCertToFolder(
        CertData certData,
        string temporaryCertificateExportFolder,
        string operation)
    {
        X509Certificate2 cert = certData.GetX509Certificate2ClientWillCallReset();
        string extension = certData.CertHasPrivateKey ? ".pfx" : ".cer";
        string filename = getFilenameSuggestionForDeletedCertificate(
            cert, temporaryCertificateExportFolder, extension, operation);

        byte[] certOctets;
        if (certData.CertHasPrivateKey && certData.PrivateKeyIsExportable)
        {
            certOctets = cert.Export(X509ContentType.Pkcs12, string.Empty);
        }
        else
        {
            certOctets = cert.Export(X509ContentType.Cert);
        }

        cert.Reset();

        using FileStream fs = new(filename, FileMode.Create, FileAccess.Write);
        fs.Write(certOctets, 0, certOctets.Length);
        fs.Flush();

        return filename;
    }

    /// <summary>
    /// Exports the certificate as PKCS12 container into the Desktop folder and the deletes
    /// by moving the file to the "Recycle bin".
    /// </summary>
    /// <param name="certData">The reference to the certificate to be deleted. </param>
    /// <param name="folder">The temporary cert export folder.</param>
    /// <returns></returns>
    private static DeleteResult exportCertificateAsPKCS12ContainerIntoFolderAndDelete(
        CertData certData, string temporaryCertificateExportFolder, bool noDeletionPrompt)
    {
        string filename = null;
        try
        {
            filename = ExportCertToFolder(certData, temporaryCertificateExportFolder, "deleted");

            Microsoft.VisualBasic.FileIO.UIOption uiOption = noDeletionPrompt ?
                Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs :
                Microsoft.VisualBasic.FileIO.UIOption.AllDialogs;

            // Move exported file into recycle bin
            Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(
                filename, uiOption,
                Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin,
                Microsoft.VisualBasic.FileIO.UICancelOption.ThrowException);

            // The user did not cancel the delete operation, so the file is successfully moved
            // into the Recycle Bin, and we can therefore delete the certificate from the store.

            X509Store store = new X509Store(certData.StoreNameAsString, certData.StoreLocation);
            store.Open(OpenFlags.ReadWrite | OpenFlags.OpenExistingOnly);
            X509Certificate2 cert = certData.GetX509Certificate2ClientWillCallReset();
            store.Remove(cert);
            store.Close();

            return DeleteResult.Deleted;
        }
        catch (Exception ex)
        {
            bool userCancelledDelete = ex is OperationCanceledException;
            bool somethingElseWentWrong = !userCancelledDelete;

            if (somethingElseWentWrong)
            {
                MessageBox.Show(string.Format(CultureInfo.CurrentCulture, "Could not export certificate to export: {0}",
                    ex.Message), "Export error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!string.IsNullOrEmpty(filename) && File.Exists(filename))
            {
                // something went wrong during the export, so re really remove our temporary export
                File.Delete(filename);
            }

            return DeleteResult.Cancelled;
        }
    }

    private static string getFilenameSuggestionForDeletedCertificate(
        X509Certificate2 cert, string folder, string extension, string operation)
    {
        DateTime now = DateTime.Now;

        StringBuilder sb = new StringBuilder();

        folder = new DirectoryInfo(folder).FullName;

        sb.Append(folder);
        if (!folder.EndsWith(string.Format("{0}", Path.DirectorySeparatorChar)))
        {
            sb.Append(Path.DirectorySeparatorChar);
        }
        sb.Append(string.Format("{0} certificate ", operation));
        sb.Append(ExportFilenameSuggestionForCertificate(cert));
        sb.Append(string.Format(" ({7} {0:d4}-{1:d2}-{2:d2}--{3:d2}-{4:d2}-{5:d2}-{6:d3})",
            now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, now.Millisecond, operation));
        sb.Append(extension);

        return sb.ToString();
    }

    private void checkBoxAllowCertDeletion_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBoxAllowCertDeletion.Checked)
        {
            this.BackColor = Color.Red;
        }
        else
        {
            this.BackColor = SystemColors.Control;
        }
    }

    private static byte[] FromHex(string input)
    {
        if (String.IsNullOrEmpty(input))
            throw new ArgumentNullException("input");

        if (input.Length % 2 == 1)
            throw new ArgumentException("Input must have an even number of characters.", "input");

        int inCount = input.Length;
        int outCount = inCount / 2;

        byte[] output = new byte[outCount];

        for (int i = 0, j = 0; i < inCount; i += 2, j++)
        {
            int x = Int32.Parse(input.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
            output[j] = (byte)x;
        }

        return output;
    }

    #endregion

    private enum ClearCertificateList
    {
        Yes,
        No
    }
}