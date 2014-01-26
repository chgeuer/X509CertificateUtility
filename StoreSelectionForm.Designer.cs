namespace X509CertificateTool
{
    partial class StoreSelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoreSelectionForm));
            this.storeNamesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.storeLocationCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBoxSearchLocations = new System.Windows.Forms.GroupBox();
            this.checkBoxRegexMatchCase = new System.Windows.Forms.CheckBox();
            this.groupBoxRegExOptions = new System.Windows.Forms.GroupBox();
            this.groupBoxSearchLocations.SuspendLayout();
            this.groupBoxRegExOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // storeNamesCheckedListBox
            // 
            this.storeNamesCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.storeNamesCheckedListBox.CheckOnClick = true;
            this.storeNamesCheckedListBox.FormattingEnabled = true;
            this.storeNamesCheckedListBox.Items.AddRange(new object[] {
            "My",
            "Root",
            "AddressBook",
            "AuthRoot",
            "CertificateAuthority",
            "Disallowed",
            "TrustedPeople",
            "TrustedPublisher"});
            this.storeNamesCheckedListBox.Location = new System.Drawing.Point(6, 59);
            this.storeNamesCheckedListBox.Name = "storeNamesCheckedListBox";
            this.storeNamesCheckedListBox.Size = new System.Drawing.Size(157, 124);
            this.storeNamesCheckedListBox.TabIndex = 0;
            // 
            // storeLocationCheckedListBox
            // 
            this.storeLocationCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.storeLocationCheckedListBox.CheckOnClick = true;
            this.storeLocationCheckedListBox.FormattingEnabled = true;
            this.storeLocationCheckedListBox.Items.AddRange(new object[] {
            "CurrentUser",
            "LocalMachine"});
            this.storeLocationCheckedListBox.Location = new System.Drawing.Point(6, 19);
            this.storeLocationCheckedListBox.Name = "storeLocationCheckedListBox";
            this.storeLocationCheckedListBox.Size = new System.Drawing.Size(157, 34);
            this.storeLocationCheckedListBox.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(142, 297);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectAll.Location = new System.Drawing.Point(6, 189);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(157, 23);
            this.buttonSelectAll.TabIndex = 3;
            this.buttonSelectAll.Text = "Reset store selection";
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(83, 297);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBoxSearchLocations
            // 
            this.groupBoxSearchLocations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSearchLocations.Controls.Add(this.storeNamesCheckedListBox);
            this.groupBoxSearchLocations.Controls.Add(this.storeLocationCheckedListBox);
            this.groupBoxSearchLocations.Controls.Add(this.buttonSelectAll);
            this.groupBoxSearchLocations.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSearchLocations.Name = "groupBoxSearchLocations";
            this.groupBoxSearchLocations.Size = new System.Drawing.Size(172, 220);
            this.groupBoxSearchLocations.TabIndex = 5;
            this.groupBoxSearchLocations.TabStop = false;
            this.groupBoxSearchLocations.Text = "Search locations";
            // 
            // checkBoxRegexMatchCase
            // 
            this.checkBoxRegexMatchCase.AutoSize = true;
            this.checkBoxRegexMatchCase.Location = new System.Drawing.Point(6, 19);
            this.checkBoxRegexMatchCase.Name = "checkBoxRegexMatchCase";
            this.checkBoxRegexMatchCase.Size = new System.Drawing.Size(79, 17);
            this.checkBoxRegexMatchCase.TabIndex = 6;
            this.checkBoxRegexMatchCase.Text = "Mach case";
            this.checkBoxRegexMatchCase.UseVisualStyleBackColor = true;
            // 
            // groupBoxRegExOptions
            // 
            this.groupBoxRegExOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxRegExOptions.Controls.Add(this.checkBoxRegexMatchCase);
            this.groupBoxRegExOptions.Location = new System.Drawing.Point(12, 238);
            this.groupBoxRegExOptions.Name = "groupBoxRegExOptions";
            this.groupBoxRegExOptions.Size = new System.Drawing.Size(172, 50);
            this.groupBoxRegExOptions.TabIndex = 7;
            this.groupBoxRegExOptions.TabStop = false;
            this.groupBoxRegExOptions.Text = "RegEx options";
            // 
            // StoreSelectionForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 334);
            this.Controls.Add(this.groupBoxRegExOptions);
            this.Controls.Add(this.groupBoxSearchLocations);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(204, 370);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(204, 370);
            this.Name = "StoreSelectionForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Search options";
            this.groupBoxSearchLocations.ResumeLayout(false);
            this.groupBoxRegExOptions.ResumeLayout(false);
            this.groupBoxRegExOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox storeNamesCheckedListBox;
        private System.Windows.Forms.CheckedListBox storeLocationCheckedListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonSelectAll;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBoxSearchLocations;
        private System.Windows.Forms.CheckBox checkBoxRegexMatchCase;
        private System.Windows.Forms.GroupBox groupBoxRegExOptions;
    }
}