namespace X509CertificateTool
{
    partial class CertificateUtilMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param storeName="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CertificateUtilMainForm));
            textBoxStoreName = new TextBox();
            textBoxStoreLocation = new TextBox();
            labelStoreLocationAndName = new Label();
            textBoxValidity = new TextBox();
            labelCertValidity = new Label();
            textBoxCertSubject = new TextBox();
            labelCertSubject = new Label();
            textBoxCertIssuer = new TextBox();
            labelCertIssuer = new Label();
            groupBoxCertificateList = new GroupBox();
            listViewCertificates = new ListView();
            _StoreLocation = new ColumnHeader();
            _StoreName = new ColumnHeader();
            _Subject = new ColumnHeader();
            _Issuer = new ColumnHeader();
            contextMenuStrip = new ContextMenuStrip(components);
            giveASPNETReadonlyAccessOnThePrivateKeyToolStripMenuItem = new ToolStripMenuItem();
            copyPublicKeyToTheClipboardToolStripMenuItem = new ToolStripMenuItem();
            copyBase64encodedCertificateToTheClipboardToolStripMenuItem = new ToolStripMenuItem();
            copyBase64encodedPKCS12CertificateToTheClipboardToolStripMenuItem = new ToolStripMenuItem();
            copyCertificateIdentifierAsWCFConfigurationToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            subjectsDistinguishedNameToolStripMenuItem = new ToolStripMenuItem();
            thumbprintToolStripMenuItem = new ToolStripMenuItem();
            exportCertificateToolStripMenuItem = new ToolStripMenuItem();
            exportCertificateAsPKCS12ContainerToolStripMenuItem = new ToolStripMenuItem();
            exportCertificatesIntoDeveloperContainerToolStripMenuItem = new ToolStripMenuItem();
            groupBoxCertificateDetails = new GroupBox();
            groupBoxCert2props = new GroupBox();
            textBoxPrivateKeyFilename = new TextBox();
            labelDisplayCertIsCACert = new Label();
            labelPrivateKeyFile = new Label();
            labelDisplayPrivateKeyIsExportable = new Label();
            labelDisplayCertHasPrivateKey = new Label();
            groupBoxSKIFlavours = new GroupBox();
            textBoxCertThumbprint = new TextBox();
            labelCertThumbprint = new Label();
            labelCertSerialNumber = new Label();
            textBoxCertSerialNumber = new TextBox();
            textBoxKeyIdentifierThumbprintSHA1 = new TextBox();
            textBoxKeyIdentifierRFC3280 = new TextBox();
            textBoxKeyIdentifierIssuerSerial = new TextBox();
            textBoxKeyIdentifierCAPI = new TextBox();
            labelKeyIdentifierThumbprintSHA1 = new Label();
            labelKeyIdentifierRFC3280 = new Label();
            labelKeyIdentifierIssuerSerial = new Label();
            labelKeyIdentifierCAPI = new Label();
            buttonShowPrivateKeyFileProperties = new Button();
            buttonViewCertificate = new Button();
            panelUserInteraction = new Panel();
            buttonInstallCertBatch = new Button();
            buttonInstallCerts = new Button();
            checkBoxNoDeletionPrompt = new CheckBox();
            checkBoxAllowCertDeletion = new CheckBox();
            buttonViewCertificateInClipboard = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            groupBoxRegex = new GroupBox();
            textBoxRegex = new TextBox();
            buttonRegexGo = new Button();
            groupBoxCryptoValue = new GroupBox();
            textBoxCryptoValue = new TextBox();
            buttonValueGo = new Button();
            buttonSearchOptions = new Button();
            buttonClearCachedCerts = new Button();
            buttonASPNET = new Button();
            groupBox2 = new GroupBox();
            errorProviderRegexTextbox = new ErrorProvider(components);
            toolTipRegex = new ToolTip(components);
            saveFileDialogPkcs12Export = new SaveFileDialog();
            saveFileDialogCertificateExport = new SaveFileDialog();
            groupBoxCertificateList.SuspendLayout();
            contextMenuStrip.SuspendLayout();
            groupBoxCertificateDetails.SuspendLayout();
            groupBoxCert2props.SuspendLayout();
            groupBoxSKIFlavours.SuspendLayout();
            panelUserInteraction.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBoxRegex.SuspendLayout();
            groupBoxCryptoValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProviderRegexTextbox).BeginInit();
            SuspendLayout();
            // 
            // textBoxStoreName
            // 
            textBoxStoreName.Location = new Point(246, 112);
            textBoxStoreName.Margin = new Padding(4, 3, 4, 3);
            textBoxStoreName.Name = "textBoxStoreName";
            textBoxStoreName.ReadOnly = true;
            textBoxStoreName.Size = new Size(418, 23);
            textBoxStoreName.TabIndex = 10;
            textBoxStoreName.TabStop = false;
            // 
            // textBoxStoreLocation
            // 
            textBoxStoreLocation.Location = new Point(79, 112);
            textBoxStoreLocation.Margin = new Padding(4, 3, 4, 3);
            textBoxStoreLocation.Name = "textBoxStoreLocation";
            textBoxStoreLocation.ReadOnly = true;
            textBoxStoreLocation.Size = new Size(159, 23);
            textBoxStoreLocation.TabIndex = 9;
            textBoxStoreLocation.TabStop = false;
            // 
            // labelStoreLocationAndName
            // 
            labelStoreLocationAndName.AutoSize = true;
            labelStoreLocationAndName.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelStoreLocationAndName.Location = new Point(7, 115);
            labelStoreLocationAndName.Margin = new Padding(4, 0, 4, 0);
            labelStoreLocationAndName.Name = "labelStoreLocationAndName";
            labelStoreLocationAndName.Size = new Size(39, 16);
            labelStoreLocationAndName.TabIndex = 8;
            labelStoreLocationAndName.Text = "Store";
            // 
            // textBoxValidity
            // 
            textBoxValidity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxValidity.Location = new Point(79, 82);
            textBoxValidity.Margin = new Padding(4, 3, 4, 3);
            textBoxValidity.Name = "textBoxValidity";
            textBoxValidity.ReadOnly = true;
            textBoxValidity.Size = new Size(585, 23);
            textBoxValidity.TabIndex = 7;
            textBoxValidity.TabStop = false;
            // 
            // labelCertValidity
            // 
            labelCertValidity.AutoSize = true;
            labelCertValidity.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCertValidity.Location = new Point(7, 83);
            labelCertValidity.Margin = new Padding(4, 0, 4, 0);
            labelCertValidity.Name = "labelCertValidity";
            labelCertValidity.Size = new Size(51, 16);
            labelCertValidity.TabIndex = 6;
            labelCertValidity.Text = "Validity";
            // 
            // textBoxCertSubject
            // 
            textBoxCertSubject.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxCertSubject.Location = new Point(79, 52);
            textBoxCertSubject.Margin = new Padding(4, 3, 4, 3);
            textBoxCertSubject.Name = "textBoxCertSubject";
            textBoxCertSubject.ReadOnly = true;
            textBoxCertSubject.Size = new Size(585, 23);
            textBoxCertSubject.TabIndex = 3;
            textBoxCertSubject.TabStop = false;
            // 
            // labelCertSubject
            // 
            labelCertSubject.AutoSize = true;
            labelCertSubject.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCertSubject.Location = new Point(7, 54);
            labelCertSubject.Margin = new Padding(4, 0, 4, 0);
            labelCertSubject.Name = "labelCertSubject";
            labelCertSubject.Size = new Size(52, 16);
            labelCertSubject.TabIndex = 2;
            labelCertSubject.Text = "Subject";
            // 
            // textBoxCertIssuer
            // 
            textBoxCertIssuer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxCertIssuer.Location = new Point(79, 22);
            textBoxCertIssuer.Margin = new Padding(4, 3, 4, 3);
            textBoxCertIssuer.Name = "textBoxCertIssuer";
            textBoxCertIssuer.ReadOnly = true;
            textBoxCertIssuer.Size = new Size(585, 23);
            textBoxCertIssuer.TabIndex = 1;
            textBoxCertIssuer.TabStop = false;
            // 
            // labelCertIssuer
            // 
            labelCertIssuer.AutoSize = true;
            labelCertIssuer.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCertIssuer.Location = new Point(7, 24);
            labelCertIssuer.Margin = new Padding(4, 0, 4, 0);
            labelCertIssuer.Name = "labelCertIssuer";
            labelCertIssuer.Size = new Size(43, 16);
            labelCertIssuer.TabIndex = 0;
            labelCertIssuer.Text = "Issuer";
            // 
            // groupBoxCertificateList
            // 
            groupBoxCertificateList.Controls.Add(listViewCertificates);
            groupBoxCertificateList.Dock = DockStyle.Fill;
            groupBoxCertificateList.Location = new Point(0, 114);
            groupBoxCertificateList.Margin = new Padding(4, 3, 4, 3);
            groupBoxCertificateList.Name = "groupBoxCertificateList";
            groupBoxCertificateList.Padding = new Padding(4, 3, 4, 3);
            groupBoxCertificateList.Size = new Size(1206, 336);
            groupBoxCertificateList.TabIndex = 0;
            groupBoxCertificateList.TabStop = false;
            groupBoxCertificateList.Text = "Matching certificates";
            // 
            // listViewCertificates
            // 
            listViewCertificates.Columns.AddRange(new ColumnHeader[] { _StoreLocation, _StoreName, _Subject, _Issuer });
            listViewCertificates.ContextMenuStrip = contextMenuStrip;
            listViewCertificates.Dock = DockStyle.Fill;
            listViewCertificates.FullRowSelect = true;
            listViewCertificates.GridLines = true;
            listViewCertificates.Location = new Point(4, 19);
            listViewCertificates.Margin = new Padding(4, 3, 4, 3);
            listViewCertificates.Name = "listViewCertificates";
            listViewCertificates.Size = new Size(1198, 314);
            listViewCertificates.Sorting = SortOrder.Ascending;
            listViewCertificates.TabIndex = 5;
            listViewCertificates.UseCompatibleStateImageBehavior = false;
            listViewCertificates.View = View.Details;
            listViewCertificates.ColumnClick += listViewCertificates_ColumnClick;
            listViewCertificates.SelectedIndexChanged += NewCertificateSelected;
            listViewCertificates.DoubleClick += DisplayCertificateUI;
            listViewCertificates.KeyDown += ListViewCertificates_KeyDown;
            listViewCertificates.MouseDown += listBox_MouseDown;
            // 
            // _StoreLocation
            // 
            _StoreLocation.Text = "Store Location";
            // 
            // _StoreName
            // 
            _StoreName.Text = "Store Name";
            // 
            // _Subject
            // 
            _Subject.Text = "Subject";
            // 
            // _Issuer
            // 
            _Issuer.Text = "Issuer";
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { giveASPNETReadonlyAccessOnThePrivateKeyToolStripMenuItem, copyPublicKeyToTheClipboardToolStripMenuItem, copyBase64encodedCertificateToTheClipboardToolStripMenuItem, copyBase64encodedPKCS12CertificateToTheClipboardToolStripMenuItem, copyCertificateIdentifierAsWCFConfigurationToolStripMenuItem, toolStripMenuItem1, exportCertificateToolStripMenuItem, exportCertificateAsPKCS12ContainerToolStripMenuItem, exportCertificatesIntoDeveloperContainerToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.Size = new Size(442, 202);
            contextMenuStrip.Opening += ContextMenuStrip_Opening;
            // 
            // giveASPNETReadonlyAccessOnThePrivateKeyToolStripMenuItem
            // 
            giveASPNETReadonlyAccessOnThePrivateKeyToolStripMenuItem.Name = "giveASPNETReadonlyAccessOnThePrivateKeyToolStripMenuItem";
            giveASPNETReadonlyAccessOnThePrivateKeyToolStripMenuItem.Size = new Size(441, 22);
            giveASPNETReadonlyAccessOnThePrivateKeyToolStripMenuItem.Text = "Give ASP.NET read-only access on the private key";
            giveASPNETReadonlyAccessOnThePrivateKeyToolStripMenuItem.Click += grantAspnetReadAccess;
            // 
            // copyPublicKeyToTheClipboardToolStripMenuItem
            // 
            copyPublicKeyToTheClipboardToolStripMenuItem.Name = "copyPublicKeyToTheClipboardToolStripMenuItem";
            copyPublicKeyToTheClipboardToolStripMenuItem.Size = new Size(441, 22);
            copyPublicKeyToTheClipboardToolStripMenuItem.Text = "Copy public key to the clipboard";
            copyPublicKeyToTheClipboardToolStripMenuItem.Click += CopyPublicKeyToClipboard;
            // 
            // copyBase64encodedCertificateToTheClipboardToolStripMenuItem
            // 
            copyBase64encodedCertificateToTheClipboardToolStripMenuItem.Name = "copyBase64encodedCertificateToTheClipboardToolStripMenuItem";
            copyBase64encodedCertificateToTheClipboardToolStripMenuItem.Size = new Size(441, 22);
            copyBase64encodedCertificateToTheClipboardToolStripMenuItem.Text = "Copy base64-encoded certificate to the clipboard";
            copyBase64encodedCertificateToTheClipboardToolStripMenuItem.Click += copyEncodedCertificateToClipboard;
            // 
            // copyBase64encodedPKCS12CertificateToTheClipboardToolStripMenuItem
            // 
            copyBase64encodedPKCS12CertificateToTheClipboardToolStripMenuItem.Name = "copyBase64encodedPKCS12CertificateToTheClipboardToolStripMenuItem";
            copyBase64encodedPKCS12CertificateToTheClipboardToolStripMenuItem.Size = new Size(441, 22);
            copyBase64encodedPKCS12CertificateToTheClipboardToolStripMenuItem.Text = "Copy base64-encoded PKCS#12-formatted certificate to the clipboard";
            copyBase64encodedPKCS12CertificateToTheClipboardToolStripMenuItem.Click += copyEncodedPKCS12CertificateToClipboard;
            // 
            // copyCertificateIdentifierAsWCFConfigurationToolStripMenuItem
            // 
            copyCertificateIdentifierAsWCFConfigurationToolStripMenuItem.Name = "copyCertificateIdentifierAsWCFConfigurationToolStripMenuItem";
            copyCertificateIdentifierAsWCFConfigurationToolStripMenuItem.Size = new Size(441, 22);
            copyCertificateIdentifierAsWCFConfigurationToolStripMenuItem.Text = "Copy certificate identifier as WCF configuration";
            copyCertificateIdentifierAsWCFConfigurationToolStripMenuItem.Click += CopyAsWCFCfg_FindBySubjectDistinguishedName;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { subjectsDistinguishedNameToolStripMenuItem, thumbprintToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(441, 22);
            toolStripMenuItem1.Text = "Copy WCF certificate information as ...";
            toolStripMenuItem1.Click += CopyAsWCFCfg_FindByThumbprint;
            // 
            // subjectsDistinguishedNameToolStripMenuItem
            // 
            subjectsDistinguishedNameToolStripMenuItem.Name = "subjectsDistinguishedNameToolStripMenuItem";
            subjectsDistinguishedNameToolStripMenuItem.Size = new Size(228, 22);
            subjectsDistinguishedNameToolStripMenuItem.Text = "Subject's distinguished name";
            subjectsDistinguishedNameToolStripMenuItem.Click += CopyAsWCFCfg_FindBySubjectDistinguishedName;
            // 
            // thumbprintToolStripMenuItem
            // 
            thumbprintToolStripMenuItem.Name = "thumbprintToolStripMenuItem";
            thumbprintToolStripMenuItem.Size = new Size(228, 22);
            thumbprintToolStripMenuItem.Text = "Thumbprint";
            // 
            // exportCertificateToolStripMenuItem
            // 
            exportCertificateToolStripMenuItem.Name = "exportCertificateToolStripMenuItem";
            exportCertificateToolStripMenuItem.Size = new Size(441, 22);
            exportCertificateToolStripMenuItem.Text = "Export certificate";
            exportCertificateToolStripMenuItem.Click += exportCertificateAsRegularCertificate;
            // 
            // exportCertificateAsPKCS12ContainerToolStripMenuItem
            // 
            exportCertificateAsPKCS12ContainerToolStripMenuItem.Name = "exportCertificateAsPKCS12ContainerToolStripMenuItem";
            exportCertificateAsPKCS12ContainerToolStripMenuItem.Size = new Size(441, 22);
            exportCertificateAsPKCS12ContainerToolStripMenuItem.Text = "Export certificate as PKCS#12 container";
            exportCertificateAsPKCS12ContainerToolStripMenuItem.Click += exportCertificateAsPKCS12Container;
            // 
            // exportCertificatesIntoDeveloperContainerToolStripMenuItem
            // 
            exportCertificatesIntoDeveloperContainerToolStripMenuItem.Name = "exportCertificatesIntoDeveloperContainerToolStripMenuItem";
            exportCertificatesIntoDeveloperContainerToolStripMenuItem.Size = new Size(441, 22);
            exportCertificatesIntoDeveloperContainerToolStripMenuItem.Text = "Export certificates into developer container";
            exportCertificatesIntoDeveloperContainerToolStripMenuItem.Click += ExportCertificatesIntoDeveloperContainer;
            // 
            // groupBoxCertificateDetails
            // 
            groupBoxCertificateDetails.Controls.Add(groupBoxCert2props);
            groupBoxCertificateDetails.Controls.Add(groupBoxSKIFlavours);
            groupBoxCertificateDetails.Dock = DockStyle.Bottom;
            groupBoxCertificateDetails.Location = new Point(0, 450);
            groupBoxCertificateDetails.Margin = new Padding(4, 3, 4, 3);
            groupBoxCertificateDetails.Name = "groupBoxCertificateDetails";
            groupBoxCertificateDetails.Padding = new Padding(4, 3, 4, 3);
            groupBoxCertificateDetails.Size = new Size(1206, 228);
            groupBoxCertificateDetails.TabIndex = 3;
            groupBoxCertificateDetails.TabStop = false;
            groupBoxCertificateDetails.Text = "Certificate details";
            // 
            // groupBoxCert2props
            // 
            groupBoxCert2props.Controls.Add(textBoxCertIssuer);
            groupBoxCert2props.Controls.Add(textBoxCertSubject);
            groupBoxCert2props.Controls.Add(textBoxValidity);
            groupBoxCert2props.Controls.Add(textBoxStoreLocation);
            groupBoxCert2props.Controls.Add(textBoxStoreName);
            groupBoxCert2props.Controls.Add(textBoxPrivateKeyFilename);
            groupBoxCert2props.Controls.Add(labelDisplayCertIsCACert);
            groupBoxCert2props.Controls.Add(labelPrivateKeyFile);
            groupBoxCert2props.Controls.Add(labelDisplayPrivateKeyIsExportable);
            groupBoxCert2props.Controls.Add(labelDisplayCertHasPrivateKey);
            groupBoxCert2props.Controls.Add(labelCertIssuer);
            groupBoxCert2props.Controls.Add(labelStoreLocationAndName);
            groupBoxCert2props.Controls.Add(labelCertSubject);
            groupBoxCert2props.Controls.Add(labelCertValidity);
            groupBoxCert2props.Dock = DockStyle.Fill;
            groupBoxCert2props.Location = new Point(4, 19);
            groupBoxCert2props.Margin = new Padding(4, 3, 4, 3);
            groupBoxCert2props.Name = "groupBoxCert2props";
            groupBoxCert2props.Padding = new Padding(4, 3, 4, 3);
            groupBoxCert2props.Size = new Size(672, 206);
            groupBoxCert2props.TabIndex = 14;
            groupBoxCert2props.TabStop = false;
            groupBoxCert2props.Text = "X509Certificate2 Properties";
            // 
            // textBoxPrivateKeyFilename
            // 
            textBoxPrivateKeyFilename.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPrivateKeyFilename.Location = new Point(79, 142);
            textBoxPrivateKeyFilename.Margin = new Padding(4, 3, 4, 3);
            textBoxPrivateKeyFilename.Name = "textBoxPrivateKeyFilename";
            textBoxPrivateKeyFilename.ReadOnly = true;
            textBoxPrivateKeyFilename.RightToLeft = RightToLeft.No;
            textBoxPrivateKeyFilename.ScrollBars = ScrollBars.Horizontal;
            textBoxPrivateKeyFilename.Size = new Size(585, 23);
            textBoxPrivateKeyFilename.TabIndex = 16;
            textBoxPrivateKeyFilename.TabStop = false;
            textBoxPrivateKeyFilename.WordWrap = false;
            textBoxPrivateKeyFilename.DoubleClick += DisplayPrivateKeyFileProperties;
            // 
            // labelDisplayCertIsCACert
            // 
            labelDisplayCertIsCACert.AutoSize = true;
            labelDisplayCertIsCACert.BorderStyle = BorderStyle.FixedSingle;
            labelDisplayCertIsCACert.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDisplayCertIsCACert.Location = new Point(357, 177);
            labelDisplayCertIsCACert.Margin = new Padding(4, 0, 4, 0);
            labelDisplayCertIsCACert.Name = "labelDisplayCertIsCACert";
            labelDisplayCertIsCACert.Size = new Size(166, 18);
            labelDisplayCertIsCACert.TabIndex = 22;
            labelDisplayCertIsCACert.Text = "Certificate belongs to a CA";
            labelDisplayCertIsCACert.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelPrivateKeyFile
            // 
            labelPrivateKeyFile.AutoSize = true;
            labelPrivateKeyFile.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPrivateKeyFile.Location = new Point(7, 143);
            labelPrivateKeyFile.Margin = new Padding(4, 0, 4, 0);
            labelPrivateKeyFile.Name = "labelPrivateKeyFile";
            labelPrivateKeyFile.Size = new Size(50, 16);
            labelPrivateKeyFile.TabIndex = 11;
            labelPrivateKeyFile.Text = "Key file";
            // 
            // labelDisplayPrivateKeyIsExportable
            // 
            labelDisplayPrivateKeyIsExportable.AutoSize = true;
            labelDisplayPrivateKeyIsExportable.BorderStyle = BorderStyle.FixedSingle;
            labelDisplayPrivateKeyIsExportable.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDisplayPrivateKeyIsExportable.Location = new Point(167, 177);
            labelDisplayPrivateKeyIsExportable.Margin = new Padding(4, 0, 4, 0);
            labelDisplayPrivateKeyIsExportable.Name = "labelDisplayPrivateKeyIsExportable";
            labelDisplayPrivateKeyIsExportable.Size = new Size(156, 18);
            labelDisplayPrivateKeyIsExportable.TabIndex = 21;
            labelDisplayPrivateKeyIsExportable.Text = "Private key is exportable";
            labelDisplayPrivateKeyIsExportable.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelDisplayCertHasPrivateKey
            // 
            labelDisplayCertHasPrivateKey.AutoSize = true;
            labelDisplayCertHasPrivateKey.BorderStyle = BorderStyle.FixedSingle;
            labelDisplayCertHasPrivateKey.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDisplayCertHasPrivateKey.Location = new Point(10, 177);
            labelDisplayCertHasPrivateKey.Margin = new Padding(4, 0, 4, 0);
            labelDisplayCertHasPrivateKey.Name = "labelDisplayCertHasPrivateKey";
            labelDisplayCertHasPrivateKey.Size = new Size(127, 18);
            labelDisplayCertHasPrivateKey.TabIndex = 20;
            labelDisplayCertHasPrivateKey.Text = "Cert has private key";
            labelDisplayCertHasPrivateKey.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBoxSKIFlavours
            // 
            groupBoxSKIFlavours.Controls.Add(textBoxCertThumbprint);
            groupBoxSKIFlavours.Controls.Add(labelCertThumbprint);
            groupBoxSKIFlavours.Controls.Add(labelCertSerialNumber);
            groupBoxSKIFlavours.Controls.Add(textBoxCertSerialNumber);
            groupBoxSKIFlavours.Controls.Add(textBoxKeyIdentifierThumbprintSHA1);
            groupBoxSKIFlavours.Controls.Add(textBoxKeyIdentifierRFC3280);
            groupBoxSKIFlavours.Controls.Add(textBoxKeyIdentifierIssuerSerial);
            groupBoxSKIFlavours.Controls.Add(textBoxKeyIdentifierCAPI);
            groupBoxSKIFlavours.Controls.Add(labelKeyIdentifierThumbprintSHA1);
            groupBoxSKIFlavours.Controls.Add(labelKeyIdentifierRFC3280);
            groupBoxSKIFlavours.Controls.Add(labelKeyIdentifierIssuerSerial);
            groupBoxSKIFlavours.Controls.Add(labelKeyIdentifierCAPI);
            groupBoxSKIFlavours.Dock = DockStyle.Right;
            groupBoxSKIFlavours.Location = new Point(676, 19);
            groupBoxSKIFlavours.Margin = new Padding(4, 3, 4, 3);
            groupBoxSKIFlavours.Name = "groupBoxSKIFlavours";
            groupBoxSKIFlavours.Padding = new Padding(4, 3, 4, 3);
            groupBoxSKIFlavours.Size = new Size(526, 206);
            groupBoxSKIFlavours.TabIndex = 13;
            groupBoxSKIFlavours.TabStop = false;
            groupBoxSKIFlavours.Text = "Subject Key Identifier Flavours";
            // 
            // textBoxCertThumbprint
            // 
            textBoxCertThumbprint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxCertThumbprint.Location = new Point(170, 54);
            textBoxCertThumbprint.Margin = new Padding(4, 3, 4, 3);
            textBoxCertThumbprint.Name = "textBoxCertThumbprint";
            textBoxCertThumbprint.ReadOnly = true;
            textBoxCertThumbprint.Size = new Size(345, 23);
            textBoxCertThumbprint.TabIndex = 25;
            textBoxCertThumbprint.TabStop = false;
            // 
            // labelCertThumbprint
            // 
            labelCertThumbprint.AutoSize = true;
            labelCertThumbprint.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCertThumbprint.Location = new Point(7, 55);
            labelCertThumbprint.Margin = new Padding(4, 0, 4, 0);
            labelCertThumbprint.Name = "labelCertThumbprint";
            labelCertThumbprint.Size = new Size(101, 16);
            labelCertThumbprint.TabIndex = 24;
            labelCertThumbprint.Text = "Cert Thumbprint";
            // 
            // labelCertSerialNumber
            // 
            labelCertSerialNumber.AutoSize = true;
            labelCertSerialNumber.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCertSerialNumber.Location = new Point(7, 25);
            labelCertSerialNumber.Margin = new Padding(4, 0, 4, 0);
            labelCertSerialNumber.Name = "labelCertSerialNumber";
            labelCertSerialNumber.Size = new Size(117, 16);
            labelCertSerialNumber.TabIndex = 23;
            labelCertSerialNumber.Text = "Cert SerialNumber";
            // 
            // textBoxCertSerialNumber
            // 
            textBoxCertSerialNumber.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxCertSerialNumber.Location = new Point(170, 24);
            textBoxCertSerialNumber.Margin = new Padding(4, 3, 4, 3);
            textBoxCertSerialNumber.Name = "textBoxCertSerialNumber";
            textBoxCertSerialNumber.ReadOnly = true;
            textBoxCertSerialNumber.Size = new Size(345, 23);
            textBoxCertSerialNumber.TabIndex = 22;
            textBoxCertSerialNumber.TabStop = false;
            // 
            // textBoxKeyIdentifierThumbprintSHA1
            // 
            textBoxKeyIdentifierThumbprintSHA1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxKeyIdentifierThumbprintSHA1.Location = new Point(170, 114);
            textBoxKeyIdentifierThumbprintSHA1.Margin = new Padding(4, 3, 4, 3);
            textBoxKeyIdentifierThumbprintSHA1.Name = "textBoxKeyIdentifierThumbprintSHA1";
            textBoxKeyIdentifierThumbprintSHA1.ReadOnly = true;
            textBoxKeyIdentifierThumbprintSHA1.Size = new Size(345, 23);
            textBoxKeyIdentifierThumbprintSHA1.TabIndex = 17;
            textBoxKeyIdentifierThumbprintSHA1.TabStop = false;
            // 
            // textBoxKeyIdentifierRFC3280
            // 
            textBoxKeyIdentifierRFC3280.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxKeyIdentifierRFC3280.Location = new Point(170, 174);
            textBoxKeyIdentifierRFC3280.Margin = new Padding(4, 3, 4, 3);
            textBoxKeyIdentifierRFC3280.Name = "textBoxKeyIdentifierRFC3280";
            textBoxKeyIdentifierRFC3280.ReadOnly = true;
            textBoxKeyIdentifierRFC3280.Size = new Size(345, 23);
            textBoxKeyIdentifierRFC3280.TabIndex = 16;
            textBoxKeyIdentifierRFC3280.TabStop = false;
            // 
            // textBoxKeyIdentifierIssuerSerial
            // 
            textBoxKeyIdentifierIssuerSerial.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxKeyIdentifierIssuerSerial.Location = new Point(170, 84);
            textBoxKeyIdentifierIssuerSerial.Margin = new Padding(4, 3, 4, 3);
            textBoxKeyIdentifierIssuerSerial.Name = "textBoxKeyIdentifierIssuerSerial";
            textBoxKeyIdentifierIssuerSerial.ReadOnly = true;
            textBoxKeyIdentifierIssuerSerial.Size = new Size(345, 23);
            textBoxKeyIdentifierIssuerSerial.TabIndex = 15;
            textBoxKeyIdentifierIssuerSerial.TabStop = false;
            // 
            // textBoxKeyIdentifierCAPI
            // 
            textBoxKeyIdentifierCAPI.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxKeyIdentifierCAPI.Location = new Point(170, 144);
            textBoxKeyIdentifierCAPI.Margin = new Padding(4, 3, 4, 3);
            textBoxKeyIdentifierCAPI.Name = "textBoxKeyIdentifierCAPI";
            textBoxKeyIdentifierCAPI.ReadOnly = true;
            textBoxKeyIdentifierCAPI.Size = new Size(345, 23);
            textBoxKeyIdentifierCAPI.TabIndex = 14;
            textBoxKeyIdentifierCAPI.TabStop = false;
            // 
            // labelKeyIdentifierThumbprintSHA1
            // 
            labelKeyIdentifierThumbprintSHA1.AutoSize = true;
            labelKeyIdentifierThumbprintSHA1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelKeyIdentifierThumbprintSHA1.Location = new Point(7, 115);
            labelKeyIdentifierThumbprintSHA1.Margin = new Padding(4, 0, 4, 0);
            labelKeyIdentifierThumbprintSHA1.Name = "labelKeyIdentifierThumbprintSHA1";
            labelKeyIdentifierThumbprintSHA1.Size = new Size(132, 16);
            labelKeyIdentifierThumbprintSHA1.TabIndex = 3;
            labelKeyIdentifierThumbprintSHA1.Text = "SKI ThumbprintSHA1";
            // 
            // labelKeyIdentifierRFC3280
            // 
            labelKeyIdentifierRFC3280.AutoSize = true;
            labelKeyIdentifierRFC3280.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelKeyIdentifierRFC3280.Location = new Point(7, 175);
            labelKeyIdentifierRFC3280.Margin = new Padding(4, 0, 4, 0);
            labelKeyIdentifierRFC3280.Name = "labelKeyIdentifierRFC3280";
            labelKeyIdentifierRFC3280.Size = new Size(85, 16);
            labelKeyIdentifierRFC3280.TabIndex = 2;
            labelKeyIdentifierRFC3280.Text = "SKI RFC3280";
            // 
            // labelKeyIdentifierIssuerSerial
            // 
            labelKeyIdentifierIssuerSerial.AutoSize = true;
            labelKeyIdentifierIssuerSerial.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelKeyIdentifierIssuerSerial.Location = new Point(7, 85);
            labelKeyIdentifierIssuerSerial.Margin = new Padding(4, 0, 4, 0);
            labelKeyIdentifierIssuerSerial.Name = "labelKeyIdentifierIssuerSerial";
            labelKeyIdentifierIssuerSerial.Size = new Size(101, 16);
            labelKeyIdentifierIssuerSerial.TabIndex = 2;
            labelKeyIdentifierIssuerSerial.Text = "SKI IssuerSerial";
            // 
            // labelKeyIdentifierCAPI
            // 
            labelKeyIdentifierCAPI.AutoSize = true;
            labelKeyIdentifierCAPI.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelKeyIdentifierCAPI.Location = new Point(7, 145);
            labelKeyIdentifierCAPI.Margin = new Padding(4, 0, 4, 0);
            labelKeyIdentifierCAPI.Name = "labelKeyIdentifierCAPI";
            labelKeyIdentifierCAPI.Size = new Size(60, 16);
            labelKeyIdentifierCAPI.TabIndex = 1;
            labelKeyIdentifierCAPI.Text = "SKI CAPI";
            // 
            // buttonShowPrivateKeyFileProperties
            // 
            buttonShowPrivateKeyFileProperties.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonShowPrivateKeyFileProperties.Enabled = false;
            buttonShowPrivateKeyFileProperties.Location = new Point(834, 59);
            buttonShowPrivateKeyFileProperties.Margin = new Padding(4, 3, 4, 3);
            buttonShowPrivateKeyFileProperties.Name = "buttonShowPrivateKeyFileProperties";
            buttonShowPrivateKeyFileProperties.Size = new Size(176, 27);
            buttonShowPrivateKeyFileProperties.TabIndex = 7;
            buttonShowPrivateKeyFileProperties.Text = "View private key properties";
            buttonShowPrivateKeyFileProperties.UseVisualStyleBackColor = true;
            buttonShowPrivateKeyFileProperties.Click += DisplayPrivateKeyFileProperties;
            // 
            // buttonViewCertificate
            // 
            buttonViewCertificate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonViewCertificate.Enabled = false;
            buttonViewCertificate.Location = new Point(723, 59);
            buttonViewCertificate.Margin = new Padding(4, 3, 4, 3);
            buttonViewCertificate.Name = "buttonViewCertificate";
            buttonViewCertificate.Size = new Size(104, 27);
            buttonViewCertificate.TabIndex = 6;
            buttonViewCertificate.Text = "View certificate";
            buttonViewCertificate.UseVisualStyleBackColor = true;
            buttonViewCertificate.Click += DisplayCertificateUI;
            // 
            // panelUserInteraction
            // 
            panelUserInteraction.Controls.Add(buttonInstallCertBatch);
            panelUserInteraction.Controls.Add(buttonInstallCerts);
            panelUserInteraction.Controls.Add(checkBoxNoDeletionPrompt);
            panelUserInteraction.Controls.Add(checkBoxAllowCertDeletion);
            panelUserInteraction.Controls.Add(buttonViewCertificateInClipboard);
            panelUserInteraction.Controls.Add(tableLayoutPanel2);
            panelUserInteraction.Controls.Add(buttonSearchOptions);
            panelUserInteraction.Controls.Add(buttonClearCachedCerts);
            panelUserInteraction.Controls.Add(buttonViewCertificate);
            panelUserInteraction.Controls.Add(buttonShowPrivateKeyFileProperties);
            panelUserInteraction.Controls.Add(buttonASPNET);
            panelUserInteraction.Dock = DockStyle.Top;
            panelUserInteraction.Location = new Point(0, 0);
            panelUserInteraction.Margin = new Padding(4, 3, 4, 3);
            panelUserInteraction.Name = "panelUserInteraction";
            panelUserInteraction.Size = new Size(1206, 114);
            panelUserInteraction.TabIndex = 4;
            // 
            // buttonInstallCertBatch
            // 
            buttonInstallCertBatch.Location = new Point(394, 88);
            buttonInstallCertBatch.Margin = new Padding(4, 3, 4, 3);
            buttonInstallCertBatch.Name = "buttonInstallCertBatch";
            buttonInstallCertBatch.Size = new Size(138, 27);
            buttonInstallCertBatch.TabIndex = 27;
            buttonInstallCertBatch.Text = "Install certs batch";
            buttonInstallCertBatch.UseVisualStyleBackColor = true;
            buttonInstallCertBatch.Click += InstallCertificatesFromDeveloperContainer;
            // 
            // buttonInstallCerts
            // 
            buttonInstallCerts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonInstallCerts.Location = new Point(394, 59);
            buttonInstallCerts.Margin = new Padding(4, 3, 4, 3);
            buttonInstallCerts.Name = "buttonInstallCerts";
            buttonInstallCerts.Size = new Size(138, 27);
            buttonInstallCerts.TabIndex = 26;
            buttonInstallCerts.Text = "Install certs";
            buttonInstallCerts.UseVisualStyleBackColor = true;
            buttonInstallCerts.Click += buttonInstallCerts_Click;
            // 
            // checkBoxNoDeletionPrompt
            // 
            checkBoxNoDeletionPrompt.AutoSize = true;
            checkBoxNoDeletionPrompt.Location = new Point(286, 88);
            checkBoxNoDeletionPrompt.Margin = new Padding(4, 3, 4, 3);
            checkBoxNoDeletionPrompt.Name = "checkBoxNoDeletionPrompt";
            checkBoxNoDeletionPrompt.Size = new Size(85, 19);
            checkBoxNoDeletionPrompt.TabIndex = 25;
            checkBoxNoDeletionPrompt.Text = "No prompt";
            checkBoxNoDeletionPrompt.UseVisualStyleBackColor = true;
            // 
            // checkBoxAllowCertDeletion
            // 
            checkBoxAllowCertDeletion.AutoSize = true;
            checkBoxAllowCertDeletion.Location = new Point(286, 63);
            checkBoxAllowCertDeletion.Margin = new Padding(4, 3, 4, 3);
            checkBoxAllowCertDeletion.Name = "checkBoxAllowCertDeletion";
            checkBoxAllowCertDeletion.Size = new Size(102, 19);
            checkBoxAllowCertDeletion.TabIndex = 24;
            checkBoxAllowCertDeletion.Text = "Allow deletion";
            checkBoxAllowCertDeletion.UseVisualStyleBackColor = true;
            checkBoxAllowCertDeletion.CheckedChanged += checkBoxAllowCertDeletion_CheckedChanged;
            // 
            // buttonViewCertificateInClipboard
            // 
            buttonViewCertificateInClipboard.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonViewCertificateInClipboard.Location = new Point(541, 59);
            buttonViewCertificateInClipboard.Margin = new Padding(4, 3, 4, 3);
            buttonViewCertificateInClipboard.Name = "buttonViewCertificateInClipboard";
            buttonViewCertificateInClipboard.Size = new Size(177, 27);
            buttonViewCertificateInClipboard.TabIndex = 23;
            buttonViewCertificateInClipboard.Text = "View certificate in clipboard";
            buttonViewCertificateInClipboard.UseVisualStyleBackColor = true;
            buttonViewCertificateInClipboard.Click += ButtonViewCertificateInClipboardClicked;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(groupBoxRegex, 0, 0);
            tableLayoutPanel2.Controls.Add(groupBoxCryptoValue, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1206, 55);
            tableLayoutPanel2.TabIndex = 21;
            // 
            // groupBoxRegex
            // 
            groupBoxRegex.Controls.Add(textBoxRegex);
            groupBoxRegex.Controls.Add(buttonRegexGo);
            groupBoxRegex.Dock = DockStyle.Fill;
            groupBoxRegex.Location = new Point(4, 3);
            groupBoxRegex.Margin = new Padding(4, 3, 4, 3);
            groupBoxRegex.Name = "groupBoxRegex";
            groupBoxRegex.Padding = new Padding(4, 3, 4, 3);
            groupBoxRegex.Size = new Size(595, 49);
            groupBoxRegex.TabIndex = 0;
            groupBoxRegex.TabStop = false;
            groupBoxRegex.Text = "RegEx search";
            // 
            // textBoxRegex
            // 
            textBoxRegex.AllowDrop = true;
            textBoxRegex.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxRegex.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxRegex.Location = new Point(7, 18);
            textBoxRegex.Margin = new Padding(4, 3, 4, 3);
            textBoxRegex.Name = "textBoxRegex";
            textBoxRegex.Size = new Size(500, 22);
            textBoxRegex.TabIndex = 0;
            toolTipRegex.SetToolTip(textBoxRegex, "Enter a .NET compatible regular expression");
            textBoxRegex.Enter += textBoxRegex_Enter;
            textBoxRegex.KeyDown += textBoxRegex_KeyDown;
            // 
            // buttonRegexGo
            // 
            buttonRegexGo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonRegexGo.Location = new Point(515, 18);
            buttonRegexGo.Margin = new Padding(4, 3, 4, 3);
            buttonRegexGo.Name = "buttonRegexGo";
            buttonRegexGo.Size = new Size(52, 27);
            buttonRegexGo.TabIndex = 1;
            buttonRegexGo.Text = "Go";
            buttonRegexGo.UseVisualStyleBackColor = true;
            buttonRegexGo.Click += buttonRegexGo_Click;
            // 
            // groupBoxCryptoValue
            // 
            groupBoxCryptoValue.Controls.Add(textBoxCryptoValue);
            groupBoxCryptoValue.Controls.Add(buttonValueGo);
            groupBoxCryptoValue.Dock = DockStyle.Fill;
            groupBoxCryptoValue.Location = new Point(607, 3);
            groupBoxCryptoValue.Margin = new Padding(4, 3, 4, 3);
            groupBoxCryptoValue.Name = "groupBoxCryptoValue";
            groupBoxCryptoValue.Padding = new Padding(4, 3, 4, 3);
            groupBoxCryptoValue.Size = new Size(595, 49);
            groupBoxCryptoValue.TabIndex = 1;
            groupBoxCryptoValue.TabStop = false;
            groupBoxCryptoValue.Text = "Crypto value search";
            // 
            // textBoxCryptoValue
            // 
            textBoxCryptoValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxCryptoValue.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCryptoValue.Location = new Point(4, 18);
            textBoxCryptoValue.Margin = new Padding(4, 3, 4, 3);
            textBoxCryptoValue.Name = "textBoxCryptoValue";
            textBoxCryptoValue.Size = new Size(508, 22);
            textBoxCryptoValue.TabIndex = 2;
            toolTipRegex.SetToolTip(textBoxCryptoValue, "Enter a Base64-encoded key identifier");
            textBoxCryptoValue.Enter += textBoxCryptoValue_Enter;
            textBoxCryptoValue.KeyDown += textBoxCryptoValue_KeyDown;
            // 
            // buttonValueGo
            // 
            buttonValueGo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonValueGo.Location = new Point(519, 17);
            buttonValueGo.Margin = new Padding(4, 3, 4, 3);
            buttonValueGo.Name = "buttonValueGo";
            buttonValueGo.Size = new Size(49, 27);
            buttonValueGo.TabIndex = 3;
            buttonValueGo.Text = "Go";
            buttonValueGo.UseVisualStyleBackColor = true;
            buttonValueGo.Click += buttonValueGo_Click;
            // 
            // buttonSearchOptions
            // 
            buttonSearchOptions.Location = new Point(4, 59);
            buttonSearchOptions.Margin = new Padding(4, 3, 4, 3);
            buttonSearchOptions.Name = "buttonSearchOptions";
            buttonSearchOptions.Size = new Size(102, 27);
            buttonSearchOptions.TabIndex = 5;
            buttonSearchOptions.Text = "Search options";
            buttonSearchOptions.UseVisualStyleBackColor = true;
            buttonSearchOptions.Click += showSearchOptions;
            // 
            // buttonClearCachedCerts
            // 
            buttonClearCachedCerts.Location = new Point(112, 59);
            buttonClearCachedCerts.Margin = new Padding(4, 3, 4, 3);
            buttonClearCachedCerts.Name = "buttonClearCachedCerts";
            buttonClearCachedCerts.Size = new Size(167, 27);
            buttonClearCachedCerts.TabIndex = 22;
            buttonClearCachedCerts.Text = "Clear cached certificates";
            buttonClearCachedCerts.UseVisualStyleBackColor = true;
            buttonClearCachedCerts.Click += ButtonClearCachedCerts_Click;
            // 
            // buttonASPNET
            // 
            buttonASPNET.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonASPNET.Enabled = false;
            buttonASPNET.Location = new Point(1017, 59);
            buttonASPNET.Margin = new Padding(4, 3, 4, 3);
            buttonASPNET.Name = "buttonASPNET";
            buttonASPNET.Size = new Size(175, 27);
            buttonASPNET.TabIndex = 8;
            buttonASPNET.Text = "Give ASP.NET read access";
            toolTipRegex.SetToolTip(buttonASPNET, "Grant the ASP.NET user account read access on the private key of the certData certificate. ");
            buttonASPNET.UseVisualStyleBackColor = true;
            buttonASPNET.Click += grantAspnetReadAccess;
            // 
            // groupBox2
            // 
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(103, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(94, 94);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Crypto value search";
            // 
            // errorProviderRegexTextbox
            // 
            errorProviderRegexTextbox.ContainerControl = this;
            // 
            // saveFileDialogPkcs12Export
            // 
            saveFileDialogPkcs12Export.DefaultExt = "p12";
            saveFileDialogPkcs12Export.Filter = "PKCS#12 files|*.p12|PFX files|*.pfx|All files|*.*";
            saveFileDialogPkcs12Export.Title = "Export to PKCS#12 file";
            // 
            // saveFileDialogCertificateExport
            // 
            saveFileDialogCertificateExport.DefaultExt = "cer";
            saveFileDialogCertificateExport.Filter = "Certificate files|*.cer|All files|*.*";
            saveFileDialogCertificateExport.Title = "Export plain certificate";
            // 
            // CertificateUtilMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1206, 678);
            Controls.Add(groupBoxCertificateList);
            Controls.Add(panelUserInteraction);
            Controls.Add(groupBoxCertificateDetails);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(1099, 496);
            Name = "CertificateUtilMainForm";
            Text = "X509 Certificate Tool";
            groupBoxCertificateList.ResumeLayout(false);
            contextMenuStrip.ResumeLayout(false);
            groupBoxCertificateDetails.ResumeLayout(false);
            groupBoxCert2props.ResumeLayout(false);
            groupBoxCert2props.PerformLayout();
            groupBoxSKIFlavours.ResumeLayout(false);
            groupBoxSKIFlavours.PerformLayout();
            panelUserInteraction.ResumeLayout(false);
            panelUserInteraction.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            groupBoxRegex.ResumeLayout(false);
            groupBoxRegex.PerformLayout();
            groupBoxCryptoValue.ResumeLayout(false);
            groupBoxCryptoValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProviderRegexTextbox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox textBoxValidity;
        private System.Windows.Forms.Label labelCertValidity;
        private System.Windows.Forms.TextBox textBoxCertSubject;
        private System.Windows.Forms.Label labelCertSubject;
        private System.Windows.Forms.TextBox textBoxCertIssuer;
        private System.Windows.Forms.Label labelCertIssuer;
        private System.Windows.Forms.TextBox textBoxStoreName;
        private System.Windows.Forms.TextBox textBoxStoreLocation;
        private System.Windows.Forms.Label labelStoreLocationAndName;
        private System.Windows.Forms.GroupBox groupBoxCertificateDetails;
        private System.Windows.Forms.GroupBox groupBoxCertificateList;
        private System.Windows.Forms.GroupBox groupBoxSKIFlavours;
        private System.Windows.Forms.Label labelKeyIdentifierIssuerSerial;
        private System.Windows.Forms.Label labelKeyIdentifierCAPI;
        private System.Windows.Forms.Label labelKeyIdentifierThumbprintSHA1;
        private System.Windows.Forms.Label labelKeyIdentifierRFC3280;
        private System.Windows.Forms.GroupBox groupBoxCert2props;
        private System.Windows.Forms.TextBox textBoxKeyIdentifierThumbprintSHA1;
        private System.Windows.Forms.TextBox textBoxKeyIdentifierRFC3280;
        private System.Windows.Forms.TextBox textBoxKeyIdentifierIssuerSerial;
        private System.Windows.Forms.TextBox textBoxKeyIdentifierCAPI;
        private System.Windows.Forms.Label labelCertSerialNumber;
        private System.Windows.Forms.TextBox textBoxCertSerialNumber;
        private System.Windows.Forms.TextBox textBoxCertThumbprint;
        private System.Windows.Forms.Label labelCertThumbprint;
        private System.Windows.Forms.TextBox textBoxPrivateKeyFilename;
        private System.Windows.Forms.Label labelPrivateKeyFile;
        private System.Windows.Forms.Button buttonShowPrivateKeyFileProperties;
        private System.Windows.Forms.Button buttonViewCertificate;
        private System.Windows.Forms.Panel panelUserInteraction;
        private System.Windows.Forms.Button buttonSearchOptions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBoxRegex;
        private System.Windows.Forms.GroupBox groupBoxCryptoValue;
        private System.Windows.Forms.ErrorProvider errorProviderRegexTextbox;
        private System.Windows.Forms.Button buttonRegexGo;
        private System.Windows.Forms.Button buttonValueGo;
        private System.Windows.Forms.TextBox textBoxCryptoValue;
        private System.Windows.Forms.TextBox textBoxRegex;
        private System.Windows.Forms.ToolTip toolTipRegex;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem giveASPNETReadonlyAccessOnThePrivateKeyToolStripMenuItem;
        private System.Windows.Forms.Button buttonASPNET;
        private System.Windows.Forms.ListView listViewCertificates;
        private System.Windows.Forms.ColumnHeader _StoreLocation;
        private System.Windows.Forms.ColumnHeader _Subject;
        private System.Windows.Forms.ColumnHeader _Issuer;
        private System.Windows.Forms.ColumnHeader _StoreName;
        private System.Windows.Forms.Label labelDisplayCertIsCACert;
        private System.Windows.Forms.Label labelDisplayPrivateKeyIsExportable;
        private System.Windows.Forms.Label labelDisplayCertHasPrivateKey;
        private System.Windows.Forms.Button buttonClearCachedCerts;
		private System.Windows.Forms.ToolStripMenuItem copyPublicKeyToTheClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyBase64encodedCertificateToTheClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyBase64encodedPKCS12CertificateToTheClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportCertificateAsPKCS12ContainerToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogPkcs12Export;
        private System.Windows.Forms.ToolStripMenuItem exportCertificateToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogCertificateExport;
        private System.Windows.Forms.Button buttonViewCertificateInClipboard;
        private System.Windows.Forms.ToolStripMenuItem copyCertificateIdentifierAsWCFConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem subjectsDistinguishedNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thumbprintToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxAllowCertDeletion;
        private System.Windows.Forms.CheckBox checkBoxNoDeletionPrompt;
        private System.Windows.Forms.Button buttonInstallCerts;
        private System.Windows.Forms.ToolStripMenuItem exportCertificatesIntoDeveloperContainerToolStripMenuItem;
        private System.Windows.Forms.Button buttonInstallCertBatch;
    }
}

