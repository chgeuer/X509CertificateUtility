namespace X509CertificateTool
{
    using System;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Windows.Forms;

    internal partial class BatchCertificateContainerImportForm : Form
    {
        public BatchCertificateContainerImportForm()
        {
            InitializeComponent();
        }

        public BatchCertificateContainerImportForm(BatchCertificateContainer container) : this()
        {
            this.FillListView(container);
        }

        private void FillListView(BatchCertificateContainer container)
        {
            this.listView1.BeginUpdate();

            container.Certs.ToList().ForEach(certData =>
                {
                    ListViewItem lvi = new ListViewItem(certData.StoreLocation.ToString());
                    lvi.SubItems.Add(certData.StoreNameAsString);
                    lvi.SubItems.Add(certData.CertSubject);
                    lvi.Tag = certData;
                    
                    listView1.Items.Add(lvi);
                });

            this.listView1.EndUpdate();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            listView1.SelectedItems.Cast<ListViewItem>().Select(
                lvi => lvi.Tag).Cast<CertData>().ToList().ForEach(certData =>
                {
                    X509Certificate2 cert = certData.GetX509Certificate2ClientWillCallReset();
                    X509Certificate2UI.DisplayCertificate(cert);
                    cert.Reset();
                });
        }
    }
}
