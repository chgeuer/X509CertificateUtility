namespace X509CertificateTool
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Linq;

    namespace CertificateInspectorExtensions
    {
        public static class CertificateInspectorExtension
        {
            public static bool HasExportablePrivateKey(this X509Certificate2 certificate)
            {
                if (certificate == null) throw new NullReferenceException();

                if (!certificate.HasPrivateKey) return false;

                return (certificate.PrivateKey is RSACryptoServiceProvider privateKey &&
                    privateKey.CspKeyContainerInfo != null &&
                    privateKey.CspKeyContainerInfo.Exportable);
            }
        }
    }

    internal class BatchCertificateContainer
    {
        internal BatchCertificateContainer() { }

        internal BatchCertificateContainer(string filename, IEnumerable<CertData> certDataItems)
        {
            this.Filename = filename;
            this.m_certs.AddRange(certDataItems);
        }

        internal BatchCertificateContainer(string filename)
        {
            this.Filename = filename;
            this.Load();
        }

        public string Filename { get; private set;}

        private readonly List<CertData> m_certs = new List<CertData>();
        public IList<CertData> Certs
        {
            get { return this.m_certs; }
        }

        public void Store()
        {
            using (FileStream fs = new FileStream(this.Filename, FileMode.Create, FileAccess.Write))
            {
                var xw = XmlWriter.Create(fs);
                var itemsElem = new XStreamingElement("Certificates", Certs.Select(c => c.ToXElement()));
                itemsElem.WriteTo(xw);
                xw.Flush();
            }
        }

        public void Load()
        {
            using (FileStream fs = File.Open(this.Filename, FileMode.Open))
            {
                m_certs.Clear();

                XDocument doc = XDocument.Load(XmlReader.Create(fs));
                XElement root = doc.Elements().First();
                var x = doc.Element("Certificates").Elements().Select(e => new CertData(e));
                m_certs.AddRange(x);
            }
        }

        internal void Install(Predicate<CertData> install)
        {
            var form = new BatchCertificateContainerImportForm(this);
            if (form.ShowDialog() == DialogResult.OK)
            {
                foreach (CertData d in m_certs)
                {
                    if (d.NotYetInStore && install(d))
                    {
                        d.Install();
                    }
                }
            }
        }
    }
}