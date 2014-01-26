namespace X509CertificateTool
{
    using System;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public partial class PfxPasswordDialog : Form
    {
        private readonly Color m_regularBackgroundColor;

        public PfxPasswordDialog()
        {
            InitializeComponent();

            this.m_regularBackgroundColor = this.BackColor;
            SetUiControlState();
        }

        private void SetUiControlState()
        {
            this.BackColor = AllowEmptyPassword ? Color.Red : m_regularBackgroundColor;
            this.SecondPasswordEntryEnabled = !ShowTypedPasswordCharacters;
            this.buttonOK.Enabled = PasswordsConsistent;
            
            textBoxPassword1.UseSystemPasswordChar = !ShowTypedPasswordCharacters;
            textBoxPassword2.UseSystemPasswordChar = !ShowTypedPasswordCharacters;
        }

        private void SetUiControlState(object sender, EventArgs e)
        {
            SetUiControlState();
        }

        private bool PasswordsConsistent
        {
            get
            {
                if (!ShowTypedPasswordCharacters &&
                    !textBoxPassword1.Text.Equals(textBoxPassword2.Text))
                {
                    return false;
                }
                if (textBoxPassword1.Text.Length == 0 && !AllowEmptyPassword)
                {
                    return false;
                }

                return true;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool SecondPasswordEntryEnabled
        {
            set
            {
                textBoxPassword2.Enabled = value;
                labelSecondPasswordEntryLabel.Enabled = value;
            }
        }

        public bool ShowTypedPasswordCharacters
        {
            get { return checkBoxShowPassword.Checked; }
        }

        public bool AllowEmptyPassword
        {
            get { return checkBoxAllowEmptyPassword.Checked; }
        }

        public string Password
        {
            get { return textBoxPassword1.Text; }
        }
    }
}