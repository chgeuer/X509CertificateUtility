namespace X509CertificateTool
{
    partial class CertificateInstallationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CertificateInstallationForm));
            this.listBoxCurrentUserMy = new System.Windows.Forms.ListBox();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelCurrentUser = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBoxCurrentUserTrustedPeople = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBoxCurrentUserRoot = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBoxCurrentUserAddressBook = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelLocalMachine = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listBoxLocalMachineMy = new System.Windows.Forms.ListBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.listBoxLocalMachineRoot = new System.Windows.Forms.ListBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.listBoxLocalMachineAddressBook = new System.Windows.Forms.ListBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.listBoxLocalMachineTrustedPeople = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.listBoxCertFiles = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxFilterDisplay = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanelMain.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tableLayoutPanelCurrentUser.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tableLayoutPanelLocalMachine.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxCurrentUserMy
            // 
            this.listBoxCurrentUserMy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxCurrentUserMy.FormattingEnabled = true;
            this.listBoxCurrentUserMy.HorizontalScrollbar = true;
            this.listBoxCurrentUserMy.Location = new System.Drawing.Point(3, 16);
            this.listBoxCurrentUserMy.Name = "listBoxCurrentUserMy";
            this.listBoxCurrentUserMy.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxCurrentUserMy.Size = new System.Drawing.Size(198, 134);
            this.listBoxCurrentUserMy.TabIndex = 0;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.groupBox7, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.groupBox8, 1, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 26);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 1;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 684F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(444, 684);
            this.tableLayoutPanelMain.TabIndex = 2;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tableLayoutPanelCurrentUser);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(3, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(216, 678);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "CurrentUser";
            // 
            // tableLayoutPanelCurrentUser
            // 
            this.tableLayoutPanelCurrentUser.ColumnCount = 1;
            this.tableLayoutPanelCurrentUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCurrentUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelCurrentUser.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanelCurrentUser.Controls.Add(this.groupBox4, 0, 3);
            this.tableLayoutPanelCurrentUser.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanelCurrentUser.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanelCurrentUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCurrentUser.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelCurrentUser.Name = "tableLayoutPanelCurrentUser";
            this.tableLayoutPanelCurrentUser.RowCount = 4;
            this.tableLayoutPanelCurrentUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCurrentUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCurrentUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCurrentUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCurrentUser.Size = new System.Drawing.Size(210, 659);
            this.tableLayoutPanelCurrentUser.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBoxCurrentUserTrustedPeople);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 331);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(204, 158);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "TrustedPeople";
            // 
            // listBoxCurrentUserTrustedPeople
            // 
            this.listBoxCurrentUserTrustedPeople.AllowDrop = true;
            this.listBoxCurrentUserTrustedPeople.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxCurrentUserTrustedPeople.FormattingEnabled = true;
            this.listBoxCurrentUserTrustedPeople.HorizontalScrollbar = true;
            this.listBoxCurrentUserTrustedPeople.Location = new System.Drawing.Point(3, 16);
            this.listBoxCurrentUserTrustedPeople.Name = "listBoxCurrentUserTrustedPeople";
            this.listBoxCurrentUserTrustedPeople.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxCurrentUserTrustedPeople.Size = new System.Drawing.Size(198, 134);
            this.listBoxCurrentUserTrustedPeople.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBoxCurrentUserRoot);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 495);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(204, 161);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Root";
            // 
            // listBoxCurrentUserRoot
            // 
            this.listBoxCurrentUserRoot.AllowDrop = true;
            this.listBoxCurrentUserRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxCurrentUserRoot.FormattingEnabled = true;
            this.listBoxCurrentUserRoot.HorizontalScrollbar = true;
            this.listBoxCurrentUserRoot.Location = new System.Drawing.Point(3, 16);
            this.listBoxCurrentUserRoot.Name = "listBoxCurrentUserRoot";
            this.listBoxCurrentUserRoot.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxCurrentUserRoot.Size = new System.Drawing.Size(198, 134);
            this.listBoxCurrentUserRoot.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxCurrentUserAddressBook);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 158);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "AddressBook";
            // 
            // listBoxCurrentUserAddressBook
            // 
            this.listBoxCurrentUserAddressBook.AllowDrop = true;
            this.listBoxCurrentUserAddressBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxCurrentUserAddressBook.FormattingEnabled = true;
            this.listBoxCurrentUserAddressBook.HorizontalScrollbar = true;
            this.listBoxCurrentUserAddressBook.Location = new System.Drawing.Point(3, 16);
            this.listBoxCurrentUserAddressBook.Name = "listBoxCurrentUserAddressBook";
            this.listBoxCurrentUserAddressBook.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxCurrentUserAddressBook.Size = new System.Drawing.Size(198, 134);
            this.listBoxCurrentUserAddressBook.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxCurrentUserMy);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "My";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.tableLayoutPanelLocalMachine);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(225, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(216, 678);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "LocalMachine";
            // 
            // tableLayoutPanelLocalMachine
            // 
            this.tableLayoutPanelLocalMachine.ColumnCount = 1;
            this.tableLayoutPanelLocalMachine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLocalMachine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelLocalMachine.Controls.Add(this.groupBox5, 0, 0);
            this.tableLayoutPanelLocalMachine.Controls.Add(this.groupBox6, 0, 3);
            this.tableLayoutPanelLocalMachine.Controls.Add(this.groupBox9, 0, 1);
            this.tableLayoutPanelLocalMachine.Controls.Add(this.groupBox10, 0, 2);
            this.tableLayoutPanelLocalMachine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLocalMachine.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelLocalMachine.Name = "tableLayoutPanelLocalMachine";
            this.tableLayoutPanelLocalMachine.RowCount = 4;
            this.tableLayoutPanelLocalMachine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelLocalMachine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelLocalMachine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelLocalMachine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelLocalMachine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelLocalMachine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelLocalMachine.Size = new System.Drawing.Size(210, 659);
            this.tableLayoutPanelLocalMachine.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listBoxLocalMachineMy);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(204, 158);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "My";
            // 
            // listBoxLocalMachineMy
            // 
            this.listBoxLocalMachineMy.AllowDrop = true;
            this.listBoxLocalMachineMy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLocalMachineMy.FormattingEnabled = true;
            this.listBoxLocalMachineMy.HorizontalScrollbar = true;
            this.listBoxLocalMachineMy.Location = new System.Drawing.Point(3, 16);
            this.listBoxLocalMachineMy.Name = "listBoxLocalMachineMy";
            this.listBoxLocalMachineMy.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxLocalMachineMy.Size = new System.Drawing.Size(198, 134);
            this.listBoxLocalMachineMy.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.listBoxLocalMachineRoot);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 495);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(204, 161);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Root";
            // 
            // listBoxLocalMachineRoot
            // 
            this.listBoxLocalMachineRoot.AllowDrop = true;
            this.listBoxLocalMachineRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLocalMachineRoot.FormattingEnabled = true;
            this.listBoxLocalMachineRoot.HorizontalScrollbar = true;
            this.listBoxLocalMachineRoot.Location = new System.Drawing.Point(3, 16);
            this.listBoxLocalMachineRoot.Name = "listBoxLocalMachineRoot";
            this.listBoxLocalMachineRoot.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxLocalMachineRoot.Size = new System.Drawing.Size(198, 134);
            this.listBoxLocalMachineRoot.TabIndex = 1;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.listBoxLocalMachineAddressBook);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox9.Location = new System.Drawing.Point(3, 167);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(204, 158);
            this.groupBox9.TabIndex = 4;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "AddressBook";
            // 
            // listBoxLocalMachineAddressBook
            // 
            this.listBoxLocalMachineAddressBook.AllowDrop = true;
            this.listBoxLocalMachineAddressBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLocalMachineAddressBook.FormattingEnabled = true;
            this.listBoxLocalMachineAddressBook.HorizontalScrollbar = true;
            this.listBoxLocalMachineAddressBook.Location = new System.Drawing.Point(3, 16);
            this.listBoxLocalMachineAddressBook.Name = "listBoxLocalMachineAddressBook";
            this.listBoxLocalMachineAddressBook.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxLocalMachineAddressBook.Size = new System.Drawing.Size(198, 134);
            this.listBoxLocalMachineAddressBook.TabIndex = 1;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.listBoxLocalMachineTrustedPeople);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox10.Location = new System.Drawing.Point(3, 331);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(204, 158);
            this.groupBox10.TabIndex = 5;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "TrustedPeople";
            // 
            // listBoxLocalMachineTrustedPeople
            // 
            this.listBoxLocalMachineTrustedPeople.AllowDrop = true;
            this.listBoxLocalMachineTrustedPeople.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLocalMachineTrustedPeople.FormattingEnabled = true;
            this.listBoxLocalMachineTrustedPeople.HorizontalScrollbar = true;
            this.listBoxLocalMachineTrustedPeople.Location = new System.Drawing.Point(3, 16);
            this.listBoxLocalMachineTrustedPeople.Name = "listBoxLocalMachineTrustedPeople";
            this.listBoxLocalMachineTrustedPeople.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxLocalMachineTrustedPeople.Size = new System.Drawing.Size(198, 134);
            this.listBoxLocalMachineTrustedPeople.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox11);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanelMain);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(655, 710);
            this.splitContainer1.SplitterDistance = 207;
            this.splitContainer1.TabIndex = 3;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.textBoxFolder);
            this.groupBox11.Controls.Add(this.listBoxCertFiles);
            this.groupBox11.Controls.Add(this.button1);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox11.Location = new System.Drawing.Point(0, 0);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(207, 710);
            this.groupBox11.TabIndex = 0;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Certificate files";
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFolder.Location = new System.Drawing.Point(3, 41);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.Size = new System.Drawing.Size(198, 20);
            this.textBoxFolder.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textBoxFolder, "Certificate file directory");
            this.textBoxFolder.TextChanged += new System.EventHandler(this.TextBoxFolder_TextChanged);
            // 
            // listBoxCertFiles
            // 
            this.listBoxCertFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxCertFiles.FormattingEnabled = true;
            this.listBoxCertFiles.Location = new System.Drawing.Point(3, 61);
            this.listBoxCertFiles.Name = "listBoxCertFiles";
            this.listBoxCertFiles.Size = new System.Drawing.Size(198, 641);
            this.listBoxCertFiles.TabIndex = 1;
            this.listBoxCertFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListBoxCertFiles_MouseDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxFilterDisplay);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 26);
            this.panel1.TabIndex = 3;
            // 
            // textBoxFilterDisplay
            // 
            this.textBoxFilterDisplay.Location = new System.Drawing.Point(6, 3);
            this.textBoxFilterDisplay.Name = "textBoxFilterDisplay";
            this.textBoxFilterDisplay.Size = new System.Drawing.Size(435, 20);
            this.textBoxFilterDisplay.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBoxFilterDisplay, "Certificate store search expression");
            this.textBoxFilterDisplay.TextChanged += new System.EventHandler(this.TextBoxFilterDisplay_TextChanged);
            // 
            // CertificateInstallationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 710);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CertificateInstallationForm";
            this.Text = "Install certificates";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.tableLayoutPanelCurrentUser.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.tableLayoutPanelLocalMachine.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxCurrentUserMy;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCurrentUser;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLocalMachine;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ListBox listBoxCurrentUserTrustedPeople;
        private System.Windows.Forms.ListBox listBoxCurrentUserRoot;
        private System.Windows.Forms.ListBox listBoxCurrentUserAddressBook;
        private System.Windows.Forms.ListBox listBoxLocalMachineMy;
        private System.Windows.Forms.ListBox listBoxLocalMachineRoot;
        private System.Windows.Forms.ListBox listBoxLocalMachineAddressBook;
        private System.Windows.Forms.ListBox listBoxLocalMachineTrustedPeople;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.ListBox listBoxCertFiles;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textBoxFolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxFilterDisplay;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

