namespace X509CertificateTool
{
    using System;
    using System.Windows.Forms;
    public class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new CertificateUtilMainForm());
        }
    }
}