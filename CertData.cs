namespace X509CertificateTool
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;
    using CertificateInspectorExtensions;

	/// <summary>
	/// This class stores information about an X509Certificate2. We have 'cheap' data which we 
	/// collect immediately (as we need it for the UI), and 'expensive' data which we only 
	/// compute on demand. 
	/// </summary>
	internal class CertData
	{
        internal byte[] m_transientCert = null;

		private CertData() { }

        internal CertData(byte[] transientCert) 
        {
            this.m_transientCert = transientCert;

            X509Certificate2 cert = new X509Certificate2(transientCert);

            this.FillCheapCertData(StoreLocation.CurrentUser, "Memory", cert);
            this.FillKeyIndentifierCertData(cert);
        }

		/// <summary>
		/// Instantiates a CertData object from a certificate. 
		/// </summary>
		/// <param storeName="storeLocation">The store storeLocation.</param>
		/// <param storeName="storeName">Name of the store.</param>
		/// <param storeName="certificate">The certificate.</param>
		/// <param storeName="computeKeyIdentifiersImmediately">if set to <see langword="true"/>, it computes the key identifier values immediately.</param>
		/// <param storeName="computePrivateKeyDataImmediately">if set to <see langword="true"/>, it computes the data related to the private key data immediately.</param>
		/// <returns></returns>
		internal static CertData FromCert(
			StoreLocation storeLocation, StoreName storeName,
			X509Certificate2 certificate,
			bool computeKeyIdentifiersImmediately,
			bool computePrivateKeyDataImmediately)
		{
			return FromCert(storeLocation, storeName.ToString(),
				certificate, computeKeyIdentifiersImmediately,
				computePrivateKeyDataImmediately);
		}

		/// <summary>
		/// Instantiates a CertData object from a certificate. 
		/// </summary>
		/// <param storeName="storeLocation">The store storeLocation.</param>
		/// <param storeName="storeName">Name of the store.</param>
		/// <param storeName="certificate">The certificate.</param>
		/// <param storeName="computeKeyIdentifiersImmediately">if set to <see langword="true"/>, it computes the key identifier values immediately.</param>
		/// <param storeName="computePrivateKeyDataImmediately">if set to <see langword="true"/>, it computes the data related to the private key data immediately.</param>
		/// <returns></returns>
		internal static CertData FromCert(
			StoreLocation storeLocation, string storeName,
			X509Certificate2 certificate,
			bool computeKeyIdentifiersImmediately,
			bool computePrivateKeyDataImmediately)
		{
			CertData certData = new CertData();

			certData.FillCheapCertData(storeLocation, storeName, certificate);

			if (computeKeyIdentifiersImmediately)
			{
				certData.FillKeyIndentifierCertData(certificate);
			}
			if (computePrivateKeyDataImmediately)
			{
				certData.FillPrivKeyCertData(certificate);
			}

			return certData;
		}

		public override bool Equals(object obj)
		{
			CertData other = obj as CertData;
			if (other == null)
			{
				return false;
			}
			return
				this.CertSubject.Equals(other.CertSubject) &&
				this.CertIssuer.Equals(other.CertIssuer) &&
				this.CertThumbprint.Equals(other.CertThumbprint) &&
				this.CertSerialNumber.Equals(other.CertSerialNumber) &&
				this.StoreLocation.Equals(other.StoreLocation) &&
				this.StoreNameAsString.Equals(other.StoreNameAsString) &&
				this.CertNotBefore.Equals(other.CertNotBefore) &&
				this.CertNotAfter.Equals(other.CertNotAfter) &&
				this.CertHasPrivateKey.Equals(other.CertHasPrivateKey);
		}

		public override string ToString()
		{
            //return String.Format(CultureInfo.CurrentCulture, 
            // "Subject=\"{0}\" Issuer=\"{1}\" Store={{{2}|{3}}}",
            //    this.CertSubject, this.CertIssuer, this.StoreLocation.ToString(),
            //    this.StoreNameAsString);
        
            
            return string.Format(CultureInfo.CurrentCulture, "{0} (Issuer \"{1}\")",
                this.CertSubject, this.CertIssuer);
        }

		private bool EqualsCertificate(X509Certificate2 cert)
		{
			return
				cert.Subject.Equals(this.CertSubject) &&
				cert.Issuer.Equals(this.CertIssuer) &&
				cert.Thumbprint.Equals(this.CertThumbprint) &&
				cert.SerialNumber.Equals(this.CertSerialNumber) &&
				cert.NotBefore.Equals(this.CertNotBefore) &&
				cert.NotAfter.Equals(this.CertNotAfter) &&
				cert.HasPrivateKey.Equals(this.CertHasPrivateKey);
		}

		internal bool IsRegexMatch(Regex regex)
		{
			return
				regex.IsMatch(this.CertSubject) ||
				regex.IsMatch(this.CertIssuer);
		}

		internal bool EqualsPublicKey(string keyAsXml)
		{
			return this.PublicKey.EqualsKeyXml(keyAsXml);
		}

		internal bool EqualsKeyIdentifier(string keyIdentifier)
		{
			return
                String.Equals(keyIdentifier, this.KeyIdentifierCAPI) ||
                String.Equals(keyIdentifier, this.KeyIdentifierThumbprintSHA1) ||
                String.Equals(keyIdentifier, this.KeyIdentifierIssuerSerial) ||
                String.Equals(keyIdentifier, this.KeyIdentifierRFC3280) ||
                String.Equals(keyIdentifier, this.CertSerialNumber, StringComparison.OrdinalIgnoreCase) ||
                String.Equals(keyIdentifier, this.CertThumbprint, StringComparison.OrdinalIgnoreCase);
		}

		private int _hashCode;

		public override int GetHashCode()
		{
			if (this._hashCode == 0)
			{
				CalculateHashCode();
			}
			return this._hashCode;
		}

		private void CalculateHashCode()
		{
			this._hashCode =
				this.CertSubject.GetHashCode() ^
				this.CertIssuer.GetHashCode() ^
				this.CertThumbprint.GetHashCode() ^
				this.CertSerialNumber.GetHashCode() ^
				this.StoreLocation.GetHashCode() ^
				this.StoreNameAsString.GetHashCode() ^
				this.CertNotBefore.GetHashCode() ^
				this.CertNotAfter.GetHashCode() ^
				this.CertHasPrivateKey.GetHashCode();
		}

		internal X509Certificate2 GetX509Certificate2ClientWillCallReset()
		{
            if (this.m_transientCert != null)
            {
                return new X509Certificate2(m_transientCert);
            }

			X509Store store = null;
			try
			{
				store = new X509Store(this.StoreNameAsString, this.StoreLocation);
				store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

				foreach (X509Certificate2 cert in store.Certificates)
				{
					if (this.EqualsCertificate(cert))
					{
						return cert;
					}
					cert.Reset();
				}
			}
			finally
			{
				if (store != null)
				{
					store.Close();
				}
			}

			throw new Exception("Certificate not found");
		}

		#region Cheap certificate data

		internal StoreLocation StoreLocation;
		internal string StoreNameAsString;
		internal string CertIssuer;
		internal string CertSubject;
		internal string CertThumbprint;
		internal string CertSerialNumber;
		internal DateTime CertNotBefore;
		internal DateTime CertNotAfter;
		internal bool CertHasPrivateKey;

		void FillCheapCertData(StoreLocation storeLocation,
							   string storeName,
							   X509Certificate2 certificate)
		{
			this.StoreLocation = storeLocation;
			this.StoreNameAsString = storeName;

			this.CertIssuer = certificate.Issuer;
			this.CertSubject = certificate.Subject;
			this.CertNotBefore = certificate.NotBefore;
			this.CertNotAfter = certificate.NotAfter;
			this.CertThumbprint = certificate.Thumbprint;
			this.CertSerialNumber = certificate.SerialNumber;
			this.CertHasPrivateKey = certificate.HasPrivateKey;

			CalculateHashCode();
		}

		#endregion

		#region KeyIdentifier functions

		private SimpleRSAPubKey _PublicKey;
		internal SimpleRSAPubKey PublicKey
		{
			get
			{
				if (this._PublicKey == null)
				{
					FillKeyIndentifierCertData();
				}
				return this._PublicKey;
			}
		}


		private string _keyIdentifierRFC3280;
		internal string KeyIdentifierRFC3280
		{
			get
			{
				if (this._keyIdentifierRFC3280 == null)
				{
					FillKeyIndentifierCertData();
				}
				return this._keyIdentifierRFC3280;
			}
		}

		private string _keyIdentifierCAPI;
		internal string KeyIdentifierCAPI
		{
			get
			{
				if (this._keyIdentifierCAPI == null)
				{
					FillKeyIndentifierCertData();
				}
				return this._keyIdentifierCAPI;
			}
		}

		private string _keyIdentifierThumbprintSHA1;
		internal string KeyIdentifierThumbprintSHA1
		{
			get
			{
				if (this._keyIdentifierThumbprintSHA1 == null)
				{
					FillKeyIndentifierCertData();
				}
				return this._keyIdentifierThumbprintSHA1;
			}
		}

		private string _keyIdentifierIssuerSerial;
		internal string KeyIdentifierIssuerSerial
		{
			get
			{
				if (this._keyIdentifierIssuerSerial == null)
				{
					FillKeyIndentifierCertData();
				}
				return this._keyIdentifierIssuerSerial;
			}
		}

		bool _onlyIssuerSerialIsDefined;
		internal bool OnlyIssuerSerialIsDefined
		{
			get
			{
				return this._onlyIssuerSerialIsDefined;
			}
		}

		void FillKeyIndentifierCertData()
		{
			X509Certificate2 cert = this.GetX509Certificate2ClientWillCallReset();
			FillKeyIndentifierCertData(cert);
			cert.Reset();
		}

		void FillKeyIndentifierCertData(X509Certificate2 certificate)
		{
			CertData.GetKeyIdentifiers(certificate,
									   out this._keyIdentifierCAPI,
									   out this._keyIdentifierThumbprintSHA1,
									   out this._keyIdentifierRFC3280,
									   out this._keyIdentifierIssuerSerial,
									   out this._onlyIssuerSerialIsDefined,
									   out this._PublicKey);
		}

		// Given a ASN.1 Encoded buffer this method decodes this buffer.
		private static string ASNDecode(byte[] id)
		{
			byte[] keyId = new byte[id.Length - 2];
			Buffer.BlockCopy(id, 2, keyId, 0, keyId.Length);
			return Convert.ToBase64String(keyId);
		}

		private static void GetKeyIdentifiers(X509Certificate2 certificate,
											  out string kiCAPI,
											  out string kiThumbprintSHA1,
											  out string kiRFC3280,
											  out string kiIssuerSerial,
											  out bool onlyIssuerSerialIsDefined,
											  out SimpleRSAPubKey publicKey)
		{
			const string SubjectKeyIdentifierOID = "2.5.29.14";
			X509SubjectKeyIdentifierExtension extensionSKI =
				certificate.Extensions[SubjectKeyIdentifierOID] as X509SubjectKeyIdentifierExtension;

			onlyIssuerSerialIsDefined = extensionSKI != null;

			if (onlyIssuerSerialIsDefined)
			{
				kiIssuerSerial = ASNDecode(extensionSKI.RawData);

				kiCAPI = kiIssuerSerial;
				kiThumbprintSHA1 = kiIssuerSerial;
				kiRFC3280 = kiIssuerSerial;
			}
			else
			{
				kiIssuerSerial = String.Empty;

				PublicKey pk = certificate.PublicKey;

				X509SubjectKeyIdentifierExtension extensionCAPI = new
					X509SubjectKeyIdentifierExtension(pk,
													  X509SubjectKeyIdentifierHashAlgorithm.CapiSha1, false);

				X509SubjectKeyIdentifierExtension extensionRfc3280 = new
					X509SubjectKeyIdentifierExtension(pk,
					                                  X509SubjectKeyIdentifierHashAlgorithm.ShortSha1, false);

				kiCAPI = ASNDecode(extensionCAPI.RawData);
				kiThumbprintSHA1 = Convert.ToBase64String(certificate.GetCertHash());
				kiRFC3280 = ASNDecode(extensionRfc3280.RawData);
			}

			publicKey = new SimpleRSAPubKey(certificate);
		}

		#endregion

		#region Private key functions

		private bool _extensionIsCACert;
		internal bool ExtensionIsCACert
		{
			get
			{
				if (!_privKeyDataFilled)
				{
					FillPrivKeyCertData();
				}
				return this._extensionIsCACert;
			}
		}
		private bool privateKeyIsExportable;
		internal bool PrivateKeyIsExportable
		{
			get
			{
				if (!_privKeyDataFilled)
				{
					FillPrivKeyCertData();
				}
				return this.privateKeyIsExportable;
			}
		}
		private string _privateKeyFileName;
		internal string PrivateKeyFileName
		{
			get
			{
				if (!_privKeyDataFilled)
				{
					FillPrivKeyCertData();
				}
				return this._privateKeyFileName;
			}
		}

		private bool _privKeyDataFilled;
		void FillPrivKeyCertData()
		{
			X509Certificate2 cert = this.GetX509Certificate2ClientWillCallReset();
			FillPrivKeyCertData(cert);
			cert.Reset();
		}

		void FillPrivKeyCertData(X509Certificate2 certificate)
		{
			if (this.CertHasPrivateKey)
			{
				try
				{
					RSACryptoServiceProvider privateKey = PrivateKey(certificate);

					this.privateKeyIsExportable = CertData.Exportable(privateKey);
					this._privateKeyFileName = CertData.PrivateKeyFilenameForCertificate(privateKey);
				}
				catch (System.Security.Cryptography.CryptographicException ce)
				{
					this.privateKeyIsExportable = false;
					this._privateKeyFileName = ce.Message;
				}
			}
			else
			{
				this.privateKeyIsExportable = false;
				this._privateKeyFileName = String.Empty;
			}

			foreach (X509Extension ext in certificate.Extensions)
			{
				X509BasicConstraintsExtension constraintExt = ext as X509BasicConstraintsExtension;
				if (constraintExt != null)
				{
					this._extensionIsCACert = constraintExt.CertificateAuthority;
					break;
				}
			}

			this._privKeyDataFilled = true;
		}

		private static RSACryptoServiceProvider PrivateKey(X509Certificate2 certificate)
		{
			return certificate.PrivateKey as RSACryptoServiceProvider;
		}

		private static bool Exportable(RSACryptoServiceProvider privateKey)
		{
			if (privateKey == null)
			{
				return false;
			}

			return privateKey.CspKeyContainerInfo.Exportable;
		}

		private static string PrivateKeyFilenameForCertificate(RSACryptoServiceProvider privateKey)
		{
			try
			{
				if (privateKey == null)
				{
					return "Private key does not exist or is not accessible";
				}

				string keyFileName = privateKey.CspKeyContainerInfo.UniqueKeyContainerName;

				string keyDirectory = null;

				#region Determine keyDirectory

				// Look up All User profile from environment variable
				string machineKeyDir = string.Format(@"{0}\Microsoft\Crypto\RSA\MachineKeys", 
				                                     Environment.GetFolderPath(
				                                     	Environment.SpecialFolder.CommonApplicationData));

				// If found
				if (Directory.GetFiles(machineKeyDir, keyFileName).Length > 0)
				{
					keyDirectory = machineKeyDir;
				}
				else
				{
					// Next try current user profile
					string userKeyDir = string.Format(@"{0}\Microsoft\Crypto\RSA\", 
					                                  Environment.GetFolderPath(
					                                  	Environment.SpecialFolder.ApplicationData));

					// for each sub keyDirectory
					foreach (string subDir in Directory.GetDirectories(userKeyDir))
					{
						// Seach the key file
						string[] fs = Directory.GetFiles(subDir, keyFileName);
						if (fs.Length == 0)
						{
							continue;
						}
						else
						{
							// found
							keyDirectory = subDir;
							break;
						}
					}
					if (keyDirectory == null)
					{
						return "Private key exists but is not accessible";
					}
				}

				#endregion

				StringBuilder sb = new StringBuilder();
				sb.Append(keyDirectory);
				sb.Append(Path.DirectorySeparatorChar);
				sb.Append(keyFileName);
				return sb.ToString();
			}
			catch (CryptographicException ce)
			{
				return ce.Message;
			}
		}

		#endregion

        public XStreamingElement ToXElement()
        {
            var c = this.GetX509Certificate2ClientWillCallReset();
            var b = c.Export(c.HasExportablePrivateKey() ?
                X509ContentType.Pfx : X509ContentType.Cert);
            c.Reset();

            var result = new XStreamingElement("Certificate",
                new XAttribute("StoreName", this.StoreNameAsString),
                new XAttribute("StoreLocation",
                    Enum.GetName(typeof(StoreLocation), this.StoreLocation)),
                new XText(Convert.ToBase64String(b)));

            return result;
        }

        public CertData(XElement e)
        {
            string storeName = e.Attribute("StoreName").Value;
            StoreLocation storeLocation = (StoreLocation) Enum.Parse(
                typeof(StoreLocation), e.Attribute("StoreLocation").Value);
            this.m_transientCert = Convert.FromBase64String(e.Value);
            X509Certificate2 certificate = new X509Certificate2(this.m_transientCert);

            this.FillCheapCertData(storeLocation, storeName, certificate);
            this.FillKeyIndentifierCertData(certificate);
            this.FillPrivKeyCertData(certificate);
        }

        internal bool NotYetInStore
        {
            get
            {
                X509Store store = null;
                try
                {
                    store = new X509Store(this.StoreNameAsString, this.StoreLocation);
                    store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

                    foreach (X509Certificate2 cert in store.Certificates)
                    {
                        if (this.CanReplaceStoreCert(cert))
                        {
                            cert.Reset();
                            return true;
                        }
                        cert.Reset();
                    }

                    return false;
                }
                finally
                {
                    if (store != null)
                    {
                        store.Close();
                    }
                }
            }
        }

        private bool CanReplaceStoreCert(X509Certificate2 storeCertificate)
        {
            return
                !storeCertificate.Subject.Equals(this.CertSubject) ||
                !storeCertificate.Issuer.Equals(this.CertIssuer) ||
                !storeCertificate.Thumbprint.Equals(this.CertThumbprint) ||
                !storeCertificate.SerialNumber.Equals(this.CertSerialNumber) ||
                !storeCertificate.NotBefore.Equals(this.CertNotBefore) ||
                !storeCertificate.NotAfter.Equals(this.CertNotAfter) ||
                (
                    !storeCertificate.HasPrivateKey &&
                    this.CertHasPrivateKey
                );
        }

        internal void Install()
        {
            if (this.NotYetInStore)
            {
                X509Store s = new X509Store(this.StoreNameAsString, this.StoreLocation);
                try 
                {             
                    s.Open(OpenFlags.ReadWrite);

                    var cert = this.GetX509Certificate2ClientWillCallReset();

                    s.Add(cert);
                }
                finally 
                {
                    s.Close();
                }
            }
        }
    }
}