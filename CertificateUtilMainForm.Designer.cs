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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CertificateUtilMainForm));
            this.textBoxStoreName = new System.Windows.Forms.TextBox();
            this.textBoxStoreLocation = new System.Windows.Forms.TextBox();
            this.labelStoreLocationAndName = new System.Windows.Forms.Label();
            this.textBoxValidity = new System.Windows.Forms.TextBox();
            this.labelCertValidity = new System.Windows.Forms.Label();
            this.textBoxCertSubject = new System.Windows.Forms.TextBox();
            this.labelCertSubject = new System.Windows.Forms.Label();
            this.textBoxCertIssuer = new System.Windows.Forms.TextBox();
            this.labelCertIssuer = new System.Windows.Forms.Label();
            this.groupBoxCertificateList = new System.Windows.Forms.GroupBox();
            this.listViewCertificates = new System.Windows.Forms.ListView();
            this._StoreLocation = new System.Windows.Forms.ColumnHeader();
            this._StoreName = new System.Windows.Forms.ColumnHeader();
            this._Subject = new System.Windows.Forms.ColumnHeader();
            this._Issuer = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.giveASPNETReadonlyAccessOnThePrivateKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyPublicKeyToTheClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyBase64encodedCertificateToTheClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyBase64encodedPKCS12CertificateToTheClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyCertificateIdentifierAsWCFConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectsDistinguishedNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thumbprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCertificateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCertificateAsPKCS12ContainerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCertificatesIntoDeveloperContainerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxCertificateDetails = new System.Windows.Forms.GroupBox();
            this.groupBoxCert2props = new System.Windows.Forms.GroupBox();
            this.textBoxPrivateKeyFilename = new System.Windows.Forms.TextBox();
            this.labelDisplayCertIsCACert = new System.Windows.Forms.Label();
            this.labelPrivateKeyFile = new System.Windows.Forms.Label();
            this.labelDisplayPrivateKeyIsExportable = new System.Windows.Forms.Label();
            this.labelDisplayCertHasPrivateKey = new System.Windows.Forms.Label();
            this.groupBoxSKIFlavours = new System.Windows.Forms.GroupBox();
            this.textBoxCertThumbprint = new System.Windows.Forms.TextBox();
            this.labelCertThumbprint = new System.Windows.Forms.Label();
            this.labelCertSerialNumber = new System.Windows.Forms.Label();
            this.textBoxCertSerialNumber = new System.Windows.Forms.TextBox();
            this.textBoxKeyIdentifierThumbprintSHA1 = new System.Windows.Forms.TextBox();
            this.textBoxKeyIdentifierRFC3280 = new System.Windows.Forms.TextBox();
            this.textBoxKeyIdentifierIssuerSerial = new System.Windows.Forms.TextBox();
            this.textBoxKeyIdentifierCAPI = new System.Windows.Forms.TextBox();
            this.labelKeyIdentifierThumbprintSHA1 = new System.Windows.Forms.Label();
            this.labelKeyIdentifierRFC3280 = new System.Windows.Forms.Label();
            this.labelKeyIdentifierIssuerSerial = new System.Windows.Forms.Label();
            this.labelKeyIdentifierCAPI = new System.Windows.Forms.Label();
            this.buttonShowPrivateKeyFileProperties = new System.Windows.Forms.Button();
            this.buttonViewCertificate = new System.Windows.Forms.Button();
            this.panelUserInteraction = new System.Windows.Forms.Panel();
            this.buttonInstallCerts = new System.Windows.Forms.Button();
            this.checkBoxNoDeletionPrompt = new System.Windows.Forms.CheckBox();
            this.checkBoxAllowCertDeletion = new System.Windows.Forms.CheckBox();
            this.buttonViewCertificateInClipboard = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxRegex = new System.Windows.Forms.GroupBox();
            this.textBoxRegex = new System.Windows.Forms.TextBox();
            this.buttonRegexGo = new System.Windows.Forms.Button();
            this.groupBoxCryptoValue = new System.Windows.Forms.GroupBox();
            this.textBoxCryptoValue = new System.Windows.Forms.TextBox();
            this.buttonValueGo = new System.Windows.Forms.Button();
            this.buttonSearchOptions = new System.Windows.Forms.Button();
            this.buttonClearCachedCerts = new System.Windows.Forms.Button();
            this.buttonASPNET = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.errorProviderRegexTextbox = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTipRegex = new System.Windows.Forms.ToolTip(this.components);
            this.saveFileDialogPkcs12Export = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialogCertificateExport = new System.Windows.Forms.SaveFileDialog();
            this.buttonInstallCertBatch = new System.Windows.Forms.Button();
            this.groupBoxCertificateList.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.groupBoxCertificateDetails.SuspendLayout();
            this.groupBoxCert2props.SuspendLayout();
            this.groupBoxSKIFlavours.SuspendLayout();
            this.panelUserInteraction.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBoxRegex.SuspendLayout();
            this.groupBoxCryptoValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderRegexTextbox)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxStoreName
            // 
            this.textBoxStoreName.Location = new System.Drawing.Point(211, 97);
            this.textBoxStoreName.Name = "textBoxStoreName";
            this.textBoxStoreName.ReadOnly = true;
            this.textBoxStoreName.Size = new System.Drawing.Size(262, 20);
            this.textBoxStoreName.TabIndex = 10;
            this.textBoxStoreName.TabStop = false;
            // 
            // textBoxStoreLocation
            // 
            this.textBoxStoreLocation.Location = new System.Drawing.Point(68, 97);
            this.textBoxStoreLocation.Name = "textBoxStoreLocation";
            this.textBoxStoreLocation.ReadOnly = true;
            this.textBoxStoreLocation.Size = new System.Drawing.Size(137, 20);
            this.textBoxStoreLocation.TabIndex = 9;
            this.textBoxStoreLocation.TabStop = false;
            // 
            // labelStoreLocationAndName
            // 
            this.labelStoreLocationAndName.AutoSize = true;
            this.labelStoreLocationAndName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStoreLocationAndName.Location = new System.Drawing.Point(6, 100);
            this.labelStoreLocationAndName.Name = "labelStoreLocationAndName";
            this.labelStoreLocationAndName.Size = new System.Drawing.Size(40, 16);
            this.labelStoreLocationAndName.TabIndex = 8;
            this.labelStoreLocationAndName.Text = "Store";
            // 
            // textBoxValidity
            // 
            this.textBoxValidity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxValidity.Location = new System.Drawing.Point(68, 71);
            this.textBoxValidity.Name = "textBoxValidity";
            this.textBoxValidity.ReadOnly = true;
            this.textBoxValidity.Size = new System.Drawing.Size(503, 20);
            this.textBoxValidity.TabIndex = 7;
            this.textBoxValidity.TabStop = false;
            // 
            // labelCertValidity
            // 
            this.labelCertValidity.AutoSize = true;
            this.labelCertValidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCertValidity.Location = new System.Drawing.Point(6, 72);
            this.labelCertValidity.Name = "labelCertValidity";
            this.labelCertValidity.Size = new System.Drawing.Size(52, 16);
            this.labelCertValidity.TabIndex = 6;
            this.labelCertValidity.Text = "Validity";
            // 
            // textBoxCertSubject
            // 
            this.textBoxCertSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCertSubject.Location = new System.Drawing.Point(68, 45);
            this.textBoxCertSubject.Name = "textBoxCertSubject";
            this.textBoxCertSubject.ReadOnly = true;
            this.textBoxCertSubject.Size = new System.Drawing.Size(503, 20);
            this.textBoxCertSubject.TabIndex = 3;
            this.textBoxCertSubject.TabStop = false;
            // 
            // labelCertSubject
            // 
            this.labelCertSubject.AutoSize = true;
            this.labelCertSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCertSubject.Location = new System.Drawing.Point(6, 47);
            this.labelCertSubject.Name = "labelCertSubject";
            this.labelCertSubject.Size = new System.Drawing.Size(53, 16);
            this.labelCertSubject.TabIndex = 2;
            this.labelCertSubject.Text = "Subject";
            // 
            // textBoxCertIssuer
            // 
            this.textBoxCertIssuer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCertIssuer.Location = new System.Drawing.Point(68, 19);
            this.textBoxCertIssuer.Name = "textBoxCertIssuer";
            this.textBoxCertIssuer.ReadOnly = true;
            this.textBoxCertIssuer.Size = new System.Drawing.Size(503, 20);
            this.textBoxCertIssuer.TabIndex = 1;
            this.textBoxCertIssuer.TabStop = false;
            // 
            // labelCertIssuer
            // 
            this.labelCertIssuer.AutoSize = true;
            this.labelCertIssuer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCertIssuer.Location = new System.Drawing.Point(6, 21);
            this.labelCertIssuer.Name = "labelCertIssuer";
            this.labelCertIssuer.Size = new System.Drawing.Size(44, 16);
            this.labelCertIssuer.TabIndex = 0;
            this.labelCertIssuer.Text = "Issuer";
            // 
            // groupBoxCertificateList
            // 
            this.groupBoxCertificateList.Controls.Add(this.listViewCertificates);
            this.groupBoxCertificateList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCertificateList.Location = new System.Drawing.Point(0, 99);
            this.groupBoxCertificateList.Name = "groupBoxCertificateList";
            this.groupBoxCertificateList.Size = new System.Drawing.Size(1034, 291);
            this.groupBoxCertificateList.TabIndex = 0;
            this.groupBoxCertificateList.TabStop = false;
            this.groupBoxCertificateList.Text = "Matching certificates";
            // 
            // listViewCertificates
            // 
            this.listViewCertificates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._StoreLocation,
            this._StoreName,
            this._Subject,
            this._Issuer});
            this.listViewCertificates.ContextMenuStrip = this.contextMenuStrip;
            this.listViewCertificates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCertificates.FullRowSelect = true;
            this.listViewCertificates.GridLines = true;
            this.listViewCertificates.HideSelection = false;
            this.listViewCertificates.Location = new System.Drawing.Point(3, 16);
            this.listViewCertificates.Name = "listViewCertificates";
            this.listViewCertificates.Size = new System.Drawing.Size(1028, 272);
            this.listViewCertificates.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewCertificates.TabIndex = 5;
            this.listViewCertificates.UseCompatibleStateImageBehavior = false;
            this.listViewCertificates.View = System.Windows.Forms.View.Details;
            this.listViewCertificates.SelectedIndexChanged += new System.EventHandler(this.newCertificateSelected);
            this.listViewCertificates.DoubleClick += new System.EventHandler(this.displayCertificateUI);
            this.listViewCertificates.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewCertificates_ColumnClick);
            this.listViewCertificates.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDown);
            this.listViewCertificates.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewCertificates_KeyDown);
            // 
            // _StoreLocation
            // 
            this._StoreLocation.Text = "Store Location";
            // 
            // _StoreName
            // 
            this._StoreName.Text = "Store Name";
            // 
            // _Subject
            // 
            this._Subject.Text = "Subject";
            // 
            // _Issuer
            // 
            this._Issuer.Text = "Issuer";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.giveASPNETReadonlyAccessOnThePrivateKeyToolStripMenuItem,
            this.copyPublicKeyToTheClipboardToolStripMenuItem,
            this.copyBase64encodedCertificateToTheClipboardToolStripMenuItem,
            this.copyBase64encodedPKCS12CertificateToTheClipboardToolStripMenuItem,
            this.copyCertificateIdentifierAsWCFConfigurationToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exportCertificateToolStripMenuItem,
            this.exportCertificateAsPKCS12ContainerToolStripMenuItem,
            this.exportCertificatesIntoDeveloperContainerToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(335, 180);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // giveASPNETReadonlyAccessOnThePrivateKeyToolStripMenuItem
            // 
            this.giveASPNETReadonlyAccessOnThePrivateKeyToolStripMenuItem.Name = "giveASPNETReadonlyAccessOnThePrivateKeyToolStripMenuItem";
            this.giveASPNETReadonlyAccessOnThePrivateKeyToolStripMenuItem.Size = new System.Drawing.Size(334, 22);
            this.giveASPNETReadonlyAccessOnThePrivateKeyToolStripMenuItem.Text = "Give ASP.NET read-only access on the private key";
            this.giveASPNETReadonlyAccessOnThePrivateKeyToolStripMenuItem.Click += new System.EventHandler(this.grantAspnetReadAccess);
            // 
            // copyPublicKeyToTheClipboardToolStripMenuItem
            // 
            this.copyPublicKeyToTheClipboardToolStripMenuItem.Name = "copyPublicKeyToTheClipboardToolStripMenuItem";
            this.copyPublicKeyToTheClipboardToolStripMenuItem.Size = new System.Drawing.Size(334, 22);
            this.copyPublicKeyToTheClipboardToolStripMenuItem.Text = "Copy public key to the clipboard";
            this.copyPublicKeyToTheClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyPublicKeyToClipboard);
            // 
            // copyBase64encodedCertificateToTheClipboardToolStripMenuItem
            // 
            this.copyBase64encodedCertificateToTheClipboardToolStripMenuItem.Name = "copyBase64encodedCertificateToTheClipboardToolStripMenuItem";
            this.copyBase64encodedCertificateToTheClipboardToolStripMenuItem.Size = new System.Drawing.Size(334, 22);
            this.copyBase64encodedCertificateToTheClipboardToolStripMenuItem.Text = "Copy base64-encoded certificate to the clipboard";
            this.copyBase64encodedCertificateToTheClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyEncodedCertificateToClipboard);
            // 
            // copyBase64encodedPKCS12CertificateToTheClipboardToolStripMenuItem
            // 
            this.copyBase64encodedPKCS12CertificateToTheClipboardToolStripMenuItem.Name = "copyBase64encodedPKCS12CertificateToTheClipboardToolStripMenuItem";
            this.copyBase64encodedPKCS12CertificateToTheClipboardToolStripMenuItem.Size = new System.Drawing.Size(334, 22);
            this.copyBase64encodedPKCS12CertificateToTheClipboardToolStripMenuItem.Text = "Copy base64-encoded PKCS#12-formatted certificate to the clipboard";
            this.copyBase64encodedPKCS12CertificateToTheClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyEncodedPKCS12CertificateToClipboard);
            // 
            // copyCertificateIdentifierAsWCFConfigurationToolStripMenuItem
            // 
            this.copyCertificateIdentifierAsWCFConfigurationToolStripMenuItem.Name = "copyCertificateIdentifierAsWCFConfigurationToolStripMenuItem";
            this.copyCertificateIdentifierAsWCFConfigurationToolStripMenuItem.Size = new System.Drawing.Size(334, 22);
            this.copyCertificateIdentifierAsWCFConfigurationToolStripMenuItem.Text = "Copy certificate identifier as WCF configuration";
            this.copyCertificateIdentifierAsWCFConfigurationToolStripMenuItem.Click += new System.EventHandler(this.copyAsWCFCfg_FindBySubjectDistinguishedName);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subjectsDistinguishedNameToolStripMenuItem,
            this.thumbprintToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(334, 22);
            this.toolStripMenuItem1.Text = "Copy WCF certificate information as ...";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.copyAsWCFCfg_FindByThumbprint);
            // 
            // subjectsDistinguishedNameToolStripMenuItem
            // 
            this.subjectsDistinguishedNameToolStripMenuItem.Name = "subjectsDistinguishedNameToolStripMenuItem";
            this.subjectsDistinguishedNameToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.subjectsDistinguishedNameToolStripMenuItem.Text = "Subject\'s distinguished name";
            this.subjectsDistinguishedNameToolStripMenuItem.Click += new System.EventHandler(this.copyAsWCFCfg_FindBySubjectDistinguishedName);
            // 
            // thumbprintToolStripMenuItem
            // 
            this.thumbprintToolStripMenuItem.Name = "thumbprintToolStripMenuItem";
            this.thumbprintToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.thumbprintToolStripMenuItem.Text = "Thumbprint";
            // 
            // exportCertificateToolStripMenuItem
            // 
            this.exportCertificateToolStripMenuItem.Name = "exportCertificateToolStripMenuItem";
            this.exportCertificateToolStripMenuItem.Size = new System.Drawing.Size(334, 22);
            this.exportCertificateToolStripMenuItem.Text = "Export certificate";
            this.exportCertificateToolStripMenuItem.Click += new System.EventHandler(this.exportCertificateAsRegularCertificate);
            // 
            // exportCertificateAsPKCS12ContainerToolStripMenuItem
            // 
            this.exportCertificateAsPKCS12ContainerToolStripMenuItem.Name = "exportCertificateAsPKCS12ContainerToolStripMenuItem";
            this.exportCertificateAsPKCS12ContainerToolStripMenuItem.Size = new System.Drawing.Size(334, 22);
            this.exportCertificateAsPKCS12ContainerToolStripMenuItem.Text = "Export certificate as PKCS#12 container";
            this.exportCertificateAsPKCS12ContainerToolStripMenuItem.Click += new System.EventHandler(this.exportCertificateAsPKCS12Container);
            // 
            // exportCertificatesIntoDeveloperContainerToolStripMenuItem
            // 
            this.exportCertificatesIntoDeveloperContainerToolStripMenuItem.Name = "exportCertificatesIntoDeveloperContainerToolStripMenuItem";
            this.exportCertificatesIntoDeveloperContainerToolStripMenuItem.Size = new System.Drawing.Size(334, 22);
            this.exportCertificatesIntoDeveloperContainerToolStripMenuItem.Text = "Export certificates into developer container";
            this.exportCertificatesIntoDeveloperContainerToolStripMenuItem.Click += new System.EventHandler(this.ExportCertificatesIntoDeveloperContainer);
            // 
            // groupBoxCertificateDetails
            // 
            this.groupBoxCertificateDetails.Controls.Add(this.groupBoxCert2props);
            this.groupBoxCertificateDetails.Controls.Add(this.groupBoxSKIFlavours);
            this.groupBoxCertificateDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxCertificateDetails.Location = new System.Drawing.Point(0, 390);
            this.groupBoxCertificateDetails.Name = "groupBoxCertificateDetails";
            this.groupBoxCertificateDetails.Size = new System.Drawing.Size(1034, 198);
            this.groupBoxCertificateDetails.TabIndex = 3;
            this.groupBoxCertificateDetails.TabStop = false;
            this.groupBoxCertificateDetails.Text = "Certificate details";
            // 
            // groupBoxCert2props
            // 
            this.groupBoxCert2props.Controls.Add(this.textBoxCertIssuer);
            this.groupBoxCert2props.Controls.Add(this.textBoxCertSubject);
            this.groupBoxCert2props.Controls.Add(this.textBoxValidity);
            this.groupBoxCert2props.Controls.Add(this.textBoxStoreLocation);
            this.groupBoxCert2props.Controls.Add(this.textBoxStoreName);
            this.groupBoxCert2props.Controls.Add(this.textBoxPrivateKeyFilename);
            this.groupBoxCert2props.Controls.Add(this.labelDisplayCertIsCACert);
            this.groupBoxCert2props.Controls.Add(this.labelPrivateKeyFile);
            this.groupBoxCert2props.Controls.Add(this.labelDisplayPrivateKeyIsExportable);
            this.groupBoxCert2props.Controls.Add(this.labelDisplayCertHasPrivateKey);
            this.groupBoxCert2props.Controls.Add(this.labelCertIssuer);
            this.groupBoxCert2props.Controls.Add(this.labelStoreLocationAndName);
            this.groupBoxCert2props.Controls.Add(this.labelCertSubject);
            this.groupBoxCert2props.Controls.Add(this.labelCertValidity);
            this.groupBoxCert2props.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCert2props.Location = new System.Drawing.Point(3, 16);
            this.groupBoxCert2props.Name = "groupBoxCert2props";
            this.groupBoxCert2props.Size = new System.Drawing.Size(577, 179);
            this.groupBoxCert2props.TabIndex = 14;
            this.groupBoxCert2props.TabStop = false;
            this.groupBoxCert2props.Text = "X509Certificate2 Properties";
            // 
            // textBoxPrivateKeyFilename
            // 
            this.textBoxPrivateKeyFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPrivateKeyFilename.Location = new System.Drawing.Point(68, 123);
            this.textBoxPrivateKeyFilename.Name = "textBoxPrivateKeyFilename";
            this.textBoxPrivateKeyFilename.ReadOnly = true;
            this.textBoxPrivateKeyFilename.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxPrivateKeyFilename.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxPrivateKeyFilename.Size = new System.Drawing.Size(503, 20);
            this.textBoxPrivateKeyFilename.TabIndex = 16;
            this.textBoxPrivateKeyFilename.TabStop = false;
            this.textBoxPrivateKeyFilename.WordWrap = false;
            this.textBoxPrivateKeyFilename.DoubleClick += new System.EventHandler(this.displayPrivateKeyFileProperties);
            // 
            // labelDisplayCertIsCACert
            // 
            this.labelDisplayCertIsCACert.AutoSize = true;
            this.labelDisplayCertIsCACert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDisplayCertIsCACert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDisplayCertIsCACert.Location = new System.Drawing.Point(306, 153);
            this.labelDisplayCertIsCACert.Name = "labelDisplayCertIsCACert";
            this.labelDisplayCertIsCACert.Size = new System.Drawing.Size(167, 18);
            this.labelDisplayCertIsCACert.TabIndex = 22;
            this.labelDisplayCertIsCACert.Text = "Certificate belongs to a CA";
            this.labelDisplayCertIsCACert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPrivateKeyFile
            // 
            this.labelPrivateKeyFile.AutoSize = true;
            this.labelPrivateKeyFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrivateKeyFile.Location = new System.Drawing.Point(6, 124);
            this.labelPrivateKeyFile.Name = "labelPrivateKeyFile";
            this.labelPrivateKeyFile.Size = new System.Drawing.Size(51, 16);
            this.labelPrivateKeyFile.TabIndex = 11;
            this.labelPrivateKeyFile.Text = "Key file";
            // 
            // labelDisplayPrivateKeyIsExportable
            // 
            this.labelDisplayPrivateKeyIsExportable.AutoSize = true;
            this.labelDisplayPrivateKeyIsExportable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDisplayPrivateKeyIsExportable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDisplayPrivateKeyIsExportable.Location = new System.Drawing.Point(143, 153);
            this.labelDisplayPrivateKeyIsExportable.Name = "labelDisplayPrivateKeyIsExportable";
            this.labelDisplayPrivateKeyIsExportable.Size = new System.Drawing.Size(157, 18);
            this.labelDisplayPrivateKeyIsExportable.TabIndex = 21;
            this.labelDisplayPrivateKeyIsExportable.Text = "Private key is exportable";
            this.labelDisplayPrivateKeyIsExportable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDisplayCertHasPrivateKey
            // 
            this.labelDisplayCertHasPrivateKey.AutoSize = true;
            this.labelDisplayCertHasPrivateKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDisplayCertHasPrivateKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDisplayCertHasPrivateKey.Location = new System.Drawing.Point(9, 153);
            this.labelDisplayCertHasPrivateKey.Name = "labelDisplayCertHasPrivateKey";
            this.labelDisplayCertHasPrivateKey.Size = new System.Drawing.Size(128, 18);
            this.labelDisplayCertHasPrivateKey.TabIndex = 20;
            this.labelDisplayCertHasPrivateKey.Text = "Cert has private key";
            this.labelDisplayCertHasPrivateKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxSKIFlavours
            // 
            this.groupBoxSKIFlavours.Controls.Add(this.textBoxCertThumbprint);
            this.groupBoxSKIFlavours.Controls.Add(this.labelCertThumbprint);
            this.groupBoxSKIFlavours.Controls.Add(this.labelCertSerialNumber);
            this.groupBoxSKIFlavours.Controls.Add(this.textBoxCertSerialNumber);
            this.groupBoxSKIFlavours.Controls.Add(this.textBoxKeyIdentifierThumbprintSHA1);
            this.groupBoxSKIFlavours.Controls.Add(this.textBoxKeyIdentifierRFC3280);
            this.groupBoxSKIFlavours.Controls.Add(this.textBoxKeyIdentifierIssuerSerial);
            this.groupBoxSKIFlavours.Controls.Add(this.textBoxKeyIdentifierCAPI);
            this.groupBoxSKIFlavours.Controls.Add(this.labelKeyIdentifierThumbprintSHA1);
            this.groupBoxSKIFlavours.Controls.Add(this.labelKeyIdentifierRFC3280);
            this.groupBoxSKIFlavours.Controls.Add(this.labelKeyIdentifierIssuerSerial);
            this.groupBoxSKIFlavours.Controls.Add(this.labelKeyIdentifierCAPI);
            this.groupBoxSKIFlavours.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxSKIFlavours.Location = new System.Drawing.Point(580, 16);
            this.groupBoxSKIFlavours.Name = "groupBoxSKIFlavours";
            this.groupBoxSKIFlavours.Size = new System.Drawing.Size(451, 179);
            this.groupBoxSKIFlavours.TabIndex = 13;
            this.groupBoxSKIFlavours.TabStop = false;
            this.groupBoxSKIFlavours.Text = "Subject Key Identifier Flavours";
            // 
            // textBoxCertThumbprint
            // 
            this.textBoxCertThumbprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCertThumbprint.Location = new System.Drawing.Point(146, 47);
            this.textBoxCertThumbprint.Name = "textBoxCertThumbprint";
            this.textBoxCertThumbprint.ReadOnly = true;
            this.textBoxCertThumbprint.Size = new System.Drawing.Size(296, 20);
            this.textBoxCertThumbprint.TabIndex = 25;
            this.textBoxCertThumbprint.TabStop = false;
            // 
            // labelCertThumbprint
            // 
            this.labelCertThumbprint.AutoSize = true;
            this.labelCertThumbprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCertThumbprint.Location = new System.Drawing.Point(6, 48);
            this.labelCertThumbprint.Name = "labelCertThumbprint";
            this.labelCertThumbprint.Size = new System.Drawing.Size(102, 16);
            this.labelCertThumbprint.TabIndex = 24;
            this.labelCertThumbprint.Text = "Cert Thumbprint";
            // 
            // labelCertSerialNumber
            // 
            this.labelCertSerialNumber.AutoSize = true;
            this.labelCertSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCertSerialNumber.Location = new System.Drawing.Point(6, 22);
            this.labelCertSerialNumber.Name = "labelCertSerialNumber";
            this.labelCertSerialNumber.Size = new System.Drawing.Size(118, 16);
            this.labelCertSerialNumber.TabIndex = 23;
            this.labelCertSerialNumber.Text = "Cert SerialNumber";
            // 
            // textBoxCertSerialNumber
            // 
            this.textBoxCertSerialNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCertSerialNumber.Location = new System.Drawing.Point(146, 21);
            this.textBoxCertSerialNumber.Name = "textBoxCertSerialNumber";
            this.textBoxCertSerialNumber.ReadOnly = true;
            this.textBoxCertSerialNumber.Size = new System.Drawing.Size(296, 20);
            this.textBoxCertSerialNumber.TabIndex = 22;
            this.textBoxCertSerialNumber.TabStop = false;
            // 
            // textBoxKeyIdentifierThumbprintSHA1
            // 
            this.textBoxKeyIdentifierThumbprintSHA1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKeyIdentifierThumbprintSHA1.Location = new System.Drawing.Point(146, 99);
            this.textBoxKeyIdentifierThumbprintSHA1.Name = "textBoxKeyIdentifierThumbprintSHA1";
            this.textBoxKeyIdentifierThumbprintSHA1.ReadOnly = true;
            this.textBoxKeyIdentifierThumbprintSHA1.Size = new System.Drawing.Size(296, 20);
            this.textBoxKeyIdentifierThumbprintSHA1.TabIndex = 17;
            this.textBoxKeyIdentifierThumbprintSHA1.TabStop = false;
            // 
            // textBoxKeyIdentifierRFC3280
            // 
            this.textBoxKeyIdentifierRFC3280.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKeyIdentifierRFC3280.Location = new System.Drawing.Point(146, 151);
            this.textBoxKeyIdentifierRFC3280.Name = "textBoxKeyIdentifierRFC3280";
            this.textBoxKeyIdentifierRFC3280.ReadOnly = true;
            this.textBoxKeyIdentifierRFC3280.Size = new System.Drawing.Size(296, 20);
            this.textBoxKeyIdentifierRFC3280.TabIndex = 16;
            this.textBoxKeyIdentifierRFC3280.TabStop = false;
            // 
            // textBoxKeyIdentifierIssuerSerial
            // 
            this.textBoxKeyIdentifierIssuerSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKeyIdentifierIssuerSerial.Location = new System.Drawing.Point(146, 73);
            this.textBoxKeyIdentifierIssuerSerial.Name = "textBoxKeyIdentifierIssuerSerial";
            this.textBoxKeyIdentifierIssuerSerial.ReadOnly = true;
            this.textBoxKeyIdentifierIssuerSerial.Size = new System.Drawing.Size(296, 20);
            this.textBoxKeyIdentifierIssuerSerial.TabIndex = 15;
            this.textBoxKeyIdentifierIssuerSerial.TabStop = false;
            // 
            // textBoxKeyIdentifierCAPI
            // 
            this.textBoxKeyIdentifierCAPI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKeyIdentifierCAPI.Location = new System.Drawing.Point(146, 125);
            this.textBoxKeyIdentifierCAPI.Name = "textBoxKeyIdentifierCAPI";
            this.textBoxKeyIdentifierCAPI.ReadOnly = true;
            this.textBoxKeyIdentifierCAPI.Size = new System.Drawing.Size(296, 20);
            this.textBoxKeyIdentifierCAPI.TabIndex = 14;
            this.textBoxKeyIdentifierCAPI.TabStop = false;
            // 
            // labelKeyIdentifierThumbprintSHA1
            // 
            this.labelKeyIdentifierThumbprintSHA1.AutoSize = true;
            this.labelKeyIdentifierThumbprintSHA1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKeyIdentifierThumbprintSHA1.Location = new System.Drawing.Point(6, 100);
            this.labelKeyIdentifierThumbprintSHA1.Name = "labelKeyIdentifierThumbprintSHA1";
            this.labelKeyIdentifierThumbprintSHA1.Size = new System.Drawing.Size(133, 16);
            this.labelKeyIdentifierThumbprintSHA1.TabIndex = 3;
            this.labelKeyIdentifierThumbprintSHA1.Text = "SKI ThumbprintSHA1";
            // 
            // labelKeyIdentifierRFC3280
            // 
            this.labelKeyIdentifierRFC3280.AutoSize = true;
            this.labelKeyIdentifierRFC3280.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKeyIdentifierRFC3280.Location = new System.Drawing.Point(6, 152);
            this.labelKeyIdentifierRFC3280.Name = "labelKeyIdentifierRFC3280";
            this.labelKeyIdentifierRFC3280.Size = new System.Drawing.Size(86, 16);
            this.labelKeyIdentifierRFC3280.TabIndex = 2;
            this.labelKeyIdentifierRFC3280.Text = "SKI RFC3280";
            // 
            // labelKeyIdentifierIssuerSerial
            // 
            this.labelKeyIdentifierIssuerSerial.AutoSize = true;
            this.labelKeyIdentifierIssuerSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKeyIdentifierIssuerSerial.Location = new System.Drawing.Point(6, 74);
            this.labelKeyIdentifierIssuerSerial.Name = "labelKeyIdentifierIssuerSerial";
            this.labelKeyIdentifierIssuerSerial.Size = new System.Drawing.Size(102, 16);
            this.labelKeyIdentifierIssuerSerial.TabIndex = 2;
            this.labelKeyIdentifierIssuerSerial.Text = "SKI IssuerSerial";
            // 
            // labelKeyIdentifierCAPI
            // 
            this.labelKeyIdentifierCAPI.AutoSize = true;
            this.labelKeyIdentifierCAPI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKeyIdentifierCAPI.Location = new System.Drawing.Point(6, 126);
            this.labelKeyIdentifierCAPI.Name = "labelKeyIdentifierCAPI";
            this.labelKeyIdentifierCAPI.Size = new System.Drawing.Size(61, 16);
            this.labelKeyIdentifierCAPI.TabIndex = 1;
            this.labelKeyIdentifierCAPI.Text = "SKI CAPI";
            // 
            // buttonShowPrivateKeyFileProperties
            // 
            this.buttonShowPrivateKeyFileProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowPrivateKeyFileProperties.Enabled = false;
            this.buttonShowPrivateKeyFileProperties.Location = new System.Drawing.Point(715, 51);
            this.buttonShowPrivateKeyFileProperties.Name = "buttonShowPrivateKeyFileProperties";
            this.buttonShowPrivateKeyFileProperties.Size = new System.Drawing.Size(151, 23);
            this.buttonShowPrivateKeyFileProperties.TabIndex = 7;
            this.buttonShowPrivateKeyFileProperties.Text = "View private key properties";
            this.buttonShowPrivateKeyFileProperties.UseVisualStyleBackColor = true;
            this.buttonShowPrivateKeyFileProperties.Click += new System.EventHandler(this.displayPrivateKeyFileProperties);
            // 
            // buttonViewCertificate
            // 
            this.buttonViewCertificate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonViewCertificate.Enabled = false;
            this.buttonViewCertificate.Location = new System.Drawing.Point(620, 51);
            this.buttonViewCertificate.Name = "buttonViewCertificate";
            this.buttonViewCertificate.Size = new System.Drawing.Size(89, 23);
            this.buttonViewCertificate.TabIndex = 6;
            this.buttonViewCertificate.Text = "View certificate";
            this.buttonViewCertificate.UseVisualStyleBackColor = true;
            this.buttonViewCertificate.Click += new System.EventHandler(this.displayCertificateUI);
            // 
            // panelUserInteraction
            // 
            this.panelUserInteraction.Controls.Add(this.buttonInstallCertBatch);
            this.panelUserInteraction.Controls.Add(this.buttonInstallCerts);
            this.panelUserInteraction.Controls.Add(this.checkBoxNoDeletionPrompt);
            this.panelUserInteraction.Controls.Add(this.checkBoxAllowCertDeletion);
            this.panelUserInteraction.Controls.Add(this.buttonViewCertificateInClipboard);
            this.panelUserInteraction.Controls.Add(this.tableLayoutPanel2);
            this.panelUserInteraction.Controls.Add(this.buttonSearchOptions);
            this.panelUserInteraction.Controls.Add(this.buttonClearCachedCerts);
            this.panelUserInteraction.Controls.Add(this.buttonViewCertificate);
            this.panelUserInteraction.Controls.Add(this.buttonShowPrivateKeyFileProperties);
            this.panelUserInteraction.Controls.Add(this.buttonASPNET);
            this.panelUserInteraction.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUserInteraction.Location = new System.Drawing.Point(0, 0);
            this.panelUserInteraction.Name = "panelUserInteraction";
            this.panelUserInteraction.Size = new System.Drawing.Size(1034, 99);
            this.panelUserInteraction.TabIndex = 4;
            // 
            // buttonInstallCerts
            // 
            this.buttonInstallCerts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInstallCerts.Location = new System.Drawing.Point(338, 51);
            this.buttonInstallCerts.Name = "buttonInstallCerts";
            this.buttonInstallCerts.Size = new System.Drawing.Size(118, 23);
            this.buttonInstallCerts.TabIndex = 26;
            this.buttonInstallCerts.Text = "Install certs";
            this.buttonInstallCerts.UseVisualStyleBackColor = true;
            this.buttonInstallCerts.Click += new System.EventHandler(this.buttonInstallCerts_Click);
            // 
            // checkBoxNoDeletionPrompt
            // 
            this.checkBoxNoDeletionPrompt.AutoSize = true;
            this.checkBoxNoDeletionPrompt.Location = new System.Drawing.Point(245, 76);
            this.checkBoxNoDeletionPrompt.Name = "checkBoxNoDeletionPrompt";
            this.checkBoxNoDeletionPrompt.Size = new System.Drawing.Size(75, 17);
            this.checkBoxNoDeletionPrompt.TabIndex = 25;
            this.checkBoxNoDeletionPrompt.Text = "No prompt";
            this.checkBoxNoDeletionPrompt.UseVisualStyleBackColor = true;
            // 
            // checkBoxAllowCertDeletion
            // 
            this.checkBoxAllowCertDeletion.AutoSize = true;
            this.checkBoxAllowCertDeletion.Location = new System.Drawing.Point(245, 55);
            this.checkBoxAllowCertDeletion.Name = "checkBoxAllowCertDeletion";
            this.checkBoxAllowCertDeletion.Size = new System.Drawing.Size(91, 17);
            this.checkBoxAllowCertDeletion.TabIndex = 24;
            this.checkBoxAllowCertDeletion.Text = "Allow deletion";
            this.checkBoxAllowCertDeletion.UseVisualStyleBackColor = true;
            this.checkBoxAllowCertDeletion.CheckedChanged += new System.EventHandler(this.checkBoxAllowCertDeletion_CheckedChanged);
            // 
            // buttonViewCertificateInClipboard
            // 
            this.buttonViewCertificateInClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonViewCertificateInClipboard.Location = new System.Drawing.Point(464, 51);
            this.buttonViewCertificateInClipboard.Name = "buttonViewCertificateInClipboard";
            this.buttonViewCertificateInClipboard.Size = new System.Drawing.Size(152, 23);
            this.buttonViewCertificateInClipboard.TabIndex = 23;
            this.buttonViewCertificateInClipboard.Text = "View certificate in clipboard";
            this.buttonViewCertificateInClipboard.UseVisualStyleBackColor = true;
            this.buttonViewCertificateInClipboard.Click += new System.EventHandler(this.buttonViewCertificateInClipboardClicked);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBoxRegex, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxCryptoValue, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1034, 48);
            this.tableLayoutPanel2.TabIndex = 21;
            // 
            // groupBoxRegex
            // 
            this.groupBoxRegex.Controls.Add(this.textBoxRegex);
            this.groupBoxRegex.Controls.Add(this.buttonRegexGo);
            this.groupBoxRegex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxRegex.Location = new System.Drawing.Point(3, 3);
            this.groupBoxRegex.Name = "groupBoxRegex";
            this.groupBoxRegex.Size = new System.Drawing.Size(511, 42);
            this.groupBoxRegex.TabIndex = 0;
            this.groupBoxRegex.TabStop = false;
            this.groupBoxRegex.Text = "RegEx search";
            // 
            // textBoxRegex
            // 
            this.textBoxRegex.AllowDrop = true;
            this.textBoxRegex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRegex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRegex.Location = new System.Drawing.Point(6, 16);
            this.textBoxRegex.Name = "textBoxRegex";
            this.textBoxRegex.Size = new System.Drawing.Size(430, 22);
            this.textBoxRegex.TabIndex = 0;
            this.toolTipRegex.SetToolTip(this.textBoxRegex, "Enter a .NET compatible regular expression");
            this.textBoxRegex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRegex_KeyDown);
            this.textBoxRegex.Enter += new System.EventHandler(this.textBoxRegex_Enter);
            // 
            // buttonRegexGo
            // 
            this.buttonRegexGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRegexGo.Location = new System.Drawing.Point(442, 16);
            this.buttonRegexGo.Name = "buttonRegexGo";
            this.buttonRegexGo.Size = new System.Drawing.Size(45, 23);
            this.buttonRegexGo.TabIndex = 1;
            this.buttonRegexGo.Text = "Go";
            this.buttonRegexGo.UseVisualStyleBackColor = true;
            this.buttonRegexGo.Click += new System.EventHandler(this.buttonRegexGo_Click);
            // 
            // groupBoxCryptoValue
            // 
            this.groupBoxCryptoValue.Controls.Add(this.textBoxCryptoValue);
            this.groupBoxCryptoValue.Controls.Add(this.buttonValueGo);
            this.groupBoxCryptoValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCryptoValue.Location = new System.Drawing.Point(520, 3);
            this.groupBoxCryptoValue.Name = "groupBoxCryptoValue";
            this.groupBoxCryptoValue.Size = new System.Drawing.Size(511, 42);
            this.groupBoxCryptoValue.TabIndex = 1;
            this.groupBoxCryptoValue.TabStop = false;
            this.groupBoxCryptoValue.Text = "Crypto value search";
            // 
            // textBoxCryptoValue
            // 
            this.textBoxCryptoValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCryptoValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCryptoValue.Location = new System.Drawing.Point(3, 16);
            this.textBoxCryptoValue.Name = "textBoxCryptoValue";
            this.textBoxCryptoValue.Size = new System.Drawing.Size(437, 22);
            this.textBoxCryptoValue.TabIndex = 2;
            this.toolTipRegex.SetToolTip(this.textBoxCryptoValue, "Enter a Base64-encoded key identifier");
            this.textBoxCryptoValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCryptoValue_KeyDown);
            this.textBoxCryptoValue.Enter += new System.EventHandler(this.textBoxCryptoValue_Enter);
            // 
            // buttonValueGo
            // 
            this.buttonValueGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonValueGo.Location = new System.Drawing.Point(446, 15);
            this.buttonValueGo.Name = "buttonValueGo";
            this.buttonValueGo.Size = new System.Drawing.Size(42, 23);
            this.buttonValueGo.TabIndex = 3;
            this.buttonValueGo.Text = "Go";
            this.buttonValueGo.UseVisualStyleBackColor = true;
            this.buttonValueGo.Click += new System.EventHandler(this.buttonValueGo_Click);
            // 
            // buttonSearchOptions
            // 
            this.buttonSearchOptions.Location = new System.Drawing.Point(3, 51);
            this.buttonSearchOptions.Name = "buttonSearchOptions";
            this.buttonSearchOptions.Size = new System.Drawing.Size(87, 23);
            this.buttonSearchOptions.TabIndex = 5;
            this.buttonSearchOptions.Text = "Search options";
            this.buttonSearchOptions.UseVisualStyleBackColor = true;
            this.buttonSearchOptions.Click += new System.EventHandler(this.showSearchOptions);
            // 
            // buttonClearCachedCerts
            // 
            this.buttonClearCachedCerts.Location = new System.Drawing.Point(96, 51);
            this.buttonClearCachedCerts.Name = "buttonClearCachedCerts";
            this.buttonClearCachedCerts.Size = new System.Drawing.Size(143, 23);
            this.buttonClearCachedCerts.TabIndex = 22;
            this.buttonClearCachedCerts.Text = "Clear cached certificates";
            this.buttonClearCachedCerts.UseVisualStyleBackColor = true;
            this.buttonClearCachedCerts.Click += new System.EventHandler(this.buttonClearCachedCerts_Click);
            // 
            // buttonASPNET
            // 
            this.buttonASPNET.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonASPNET.Enabled = false;
            this.buttonASPNET.Location = new System.Drawing.Point(872, 51);
            this.buttonASPNET.Name = "buttonASPNET";
            this.buttonASPNET.Size = new System.Drawing.Size(150, 23);
            this.buttonASPNET.TabIndex = 8;
            this.buttonASPNET.Text = "Give ASP.NET read access";
            this.toolTipRegex.SetToolTip(this.buttonASPNET, "Grant the ASP.NET user account read access on the private key of the certData cer" +
                    "tificate. ");
            this.buttonASPNET.UseVisualStyleBackColor = true;
            this.buttonASPNET.Click += new System.EventHandler(this.grantAspnetReadAccess);
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(103, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(94, 94);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Crypto value search";
            // 
            // errorProviderRegexTextbox
            // 
            this.errorProviderRegexTextbox.ContainerControl = this;
            // 
            // saveFileDialogPkcs12Export
            // 
            this.saveFileDialogPkcs12Export.DefaultExt = "p12";
            this.saveFileDialogPkcs12Export.Filter = "PKCS#12 files|*.p12|PFX files|*.pfx|All files|*.*";
            this.saveFileDialogPkcs12Export.Title = "Export to PKCS#12 file";
            // 
            // saveFileDialogCertificateExport
            // 
            this.saveFileDialogCertificateExport.DefaultExt = "cer";
            this.saveFileDialogCertificateExport.Filter = "Certificate files|*.cer|All files|*.*";
            this.saveFileDialogCertificateExport.Title = "Export plain certificate";
            // 
            // buttonInstallCertBatch
            // 
            this.buttonInstallCertBatch.Location = new System.Drawing.Point(338, 76);
            this.buttonInstallCertBatch.Name = "buttonInstallCertBatch";
            this.buttonInstallCertBatch.Size = new System.Drawing.Size(118, 23);
            this.buttonInstallCertBatch.TabIndex = 27;
            this.buttonInstallCertBatch.Text = "Install certs batch";
            this.buttonInstallCertBatch.UseVisualStyleBackColor = true;
            this.buttonInstallCertBatch.Click += new System.EventHandler(this.InstallCertificatesFromDeveloperContainer);
            // 
            // CertificateUtilMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 588);
            this.Controls.Add(this.groupBoxCertificateList);
            this.Controls.Add(this.panelUserInteraction);
            this.Controls.Add(this.groupBoxCertificateDetails);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(944, 435);
            this.Name = "CertificateUtilMainForm";
            this.Text = "X509 Certificate Tool";
            this.groupBoxCertificateList.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.groupBoxCertificateDetails.ResumeLayout(false);
            this.groupBoxCert2props.ResumeLayout(false);
            this.groupBoxCert2props.PerformLayout();
            this.groupBoxSKIFlavours.ResumeLayout(false);
            this.groupBoxSKIFlavours.PerformLayout();
            this.panelUserInteraction.ResumeLayout(false);
            this.panelUserInteraction.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBoxRegex.ResumeLayout(false);
            this.groupBoxRegex.PerformLayout();
            this.groupBoxCryptoValue.ResumeLayout(false);
            this.groupBoxCryptoValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderRegexTextbox)).EndInit();
            this.ResumeLayout(false);

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

