namespace X509CertificateTool;

using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

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
        m_transientCert = transientCert;

        X509Certificate2 cert = new(transientCert);

        FillCheapCertData(StoreLocation.CurrentUser, "Memory", cert);
        FillKeyIndentifierCertData(cert);
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
		CertData certData = new ();

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
        if (obj is not CertData other)
        {
            return false;
        }

        return
			CertSubject.Equals(other.CertSubject) &&
			CertIssuer.Equals(other.CertIssuer) &&
			CertThumbprint.Equals(other.CertThumbprint) &&
			CertSerialNumber.Equals(other.CertSerialNumber) &&
			StoreLocation.Equals(other.StoreLocation) &&
			StoreNameAsString.Equals(other.StoreNameAsString) &&
			CertNotBefore.Equals(other.CertNotBefore) &&
			CertNotAfter.Equals(other.CertNotAfter) &&
			CertHasPrivateKey.Equals(other.CertHasPrivateKey);
	}

	public override string ToString() => $"{CertSubject} (Issuer \"{CertIssuer}\")";

	private bool EqualsCertificate(X509Certificate2 cert)
	{
		return
			cert.Subject.Equals(CertSubject) &&
			cert.Issuer.Equals(CertIssuer) &&
			cert.Thumbprint.Equals(CertThumbprint) &&
			cert.SerialNumber.Equals(CertSerialNumber) &&
			cert.NotBefore.Equals(CertNotBefore) &&
			cert.NotAfter.Equals(CertNotAfter) &&
			cert.HasPrivateKey.Equals(CertHasPrivateKey);
	}

	internal bool IsRegexMatch(Regex regex)
	{
		return
			regex.IsMatch(CertSubject) ||
			regex.IsMatch(CertIssuer);
	}

	internal bool EqualsPublicKey(string keyAsXml)
	{
		return PublicKey.EqualsKeyXml(keyAsXml);
	}

	internal bool EqualsKeyIdentifier(string keyIdentifier)
	{
		return
			string.Equals(keyIdentifier, KeyIdentifierCAPI) ||
			string.Equals(keyIdentifier, KeyIdentifierThumbprintSHA1) ||
			string.Equals(keyIdentifier, KeyIdentifierIssuerSerial) ||
			string.Equals(keyIdentifier, KeyIdentifierRFC3280) ||
			string.Equals(keyIdentifier, CertSerialNumber, StringComparison.OrdinalIgnoreCase) ||
			string.Equals(keyIdentifier, CertThumbprint, StringComparison.OrdinalIgnoreCase);
	}

	private int _hashCode;

	public override int GetHashCode()
	{
		if (_hashCode == 0)
		{
			CalculateHashCode();
		}
		return _hashCode;
	}

	private void CalculateHashCode()
	{
		_hashCode =
			CertSubject.GetHashCode() ^
			CertIssuer.GetHashCode() ^
			CertThumbprint.GetHashCode() ^
			CertSerialNumber.GetHashCode() ^
			StoreLocation.GetHashCode() ^
			StoreNameAsString.GetHashCode() ^
			CertNotBefore.GetHashCode() ^
			CertNotAfter.GetHashCode() ^
			CertHasPrivateKey.GetHashCode();
	}

	internal X509Certificate2 GetX509Certificate2ClientWillCallReset()
	{
        if (m_transientCert != null)
        {
            return new X509Certificate2(m_transientCert);
        }

		X509Store store = null;
		try
		{
			store = new X509Store(StoreNameAsString, StoreLocation);
			store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

			foreach (X509Certificate2 cert in store.Certificates)
			{
				if (EqualsCertificate(cert))
				{
					return cert;
				}
				cert.Reset();
			}
		}
		finally
		{
			store?.Close();
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
		StoreLocation = storeLocation;
		StoreNameAsString = storeName;

		CertIssuer = certificate.Issuer;
		CertSubject = certificate.Subject;
		CertNotBefore = certificate.NotBefore;
		CertNotAfter = certificate.NotAfter;
		CertThumbprint = certificate.Thumbprint;
		CertSerialNumber = certificate.SerialNumber;
		CertHasPrivateKey = certificate.HasPrivateKey;

		CalculateHashCode();
	}

	#endregion

	#region KeyIdentifier functions

	private SimpleRSAPubKey _PublicKey;
	internal SimpleRSAPubKey PublicKey
	{
		get
		{
			if (_PublicKey == null)
			{
				FillKeyIndentifierCertData();
			}
			return _PublicKey;
		}
	}

	private string _keyIdentifierRFC3280;
	internal string KeyIdentifierRFC3280
	{
		get
		{
			if (_keyIdentifierRFC3280 == null)
			{
				FillKeyIndentifierCertData();
			}
			return _keyIdentifierRFC3280;
		}
	}

	private string _keyIdentifierCAPI;
	internal string KeyIdentifierCAPI
	{
		get
		{
			if (_keyIdentifierCAPI == null)
			{
				FillKeyIndentifierCertData();
			}
			return _keyIdentifierCAPI;
		}
	}

	private string _keyIdentifierThumbprintSHA1;
	internal string KeyIdentifierThumbprintSHA1
	{
		get
		{
			if (_keyIdentifierThumbprintSHA1 == null)
			{
				FillKeyIndentifierCertData();
			}
			return _keyIdentifierThumbprintSHA1;
		}
	}

	private string _keyIdentifierIssuerSerial;
	internal string KeyIdentifierIssuerSerial
	{
		get
		{
			if (_keyIdentifierIssuerSerial == null)
			{
				FillKeyIndentifierCertData();
			}
			return _keyIdentifierIssuerSerial;
		}
	}

	bool _onlyIssuerSerialIsDefined;
	internal bool OnlyIssuerSerialIsDefined
	{
		get
		{
			return _onlyIssuerSerialIsDefined;
		}
	}

	void FillKeyIndentifierCertData()
	{
		X509Certificate2 cert = GetX509Certificate2ClientWillCallReset();
		FillKeyIndentifierCertData(cert);
		cert.Reset();
	}

	void FillKeyIndentifierCertData(X509Certificate2 certificate)
	{
		GetKeyIdentifiers(certificate,
			out _keyIdentifierCAPI,
			out _keyIdentifierThumbprintSHA1,
			out _keyIdentifierRFC3280,
			out _keyIdentifierIssuerSerial,
			out _onlyIssuerSerialIsDefined,
			out _PublicKey);
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
			kiIssuerSerial = string.Empty;
			PublicKey pk = certificate.PublicKey;
			X509SubjectKeyIdentifierExtension extensionCAPI = new(pk, X509SubjectKeyIdentifierHashAlgorithm.CapiSha1, false);
			X509SubjectKeyIdentifierExtension extensionRfc3280 = new(pk, X509SubjectKeyIdentifierHashAlgorithm.ShortSha1, false);

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
			return _extensionIsCACert;
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
			return privateKeyIsExportable;
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
			return _privateKeyFileName;
		}
	}

	private bool _privKeyDataFilled;
	void FillPrivKeyCertData()
	{
		X509Certificate2 cert = GetX509Certificate2ClientWillCallReset();
		FillPrivKeyCertData(cert);
		cert.Reset();
	}

	void FillPrivKeyCertData(X509Certificate2 certificate)
	{
		if (CertHasPrivateKey)
		{
			try
			{
				RSACryptoServiceProvider privateKey = PrivateKey(certificate);

				privateKeyIsExportable = CertData.Exportable(privateKey);
				_privateKeyFileName = CertData.PrivateKeyFilenameForCertificate(privateKey);
			}
			catch (System.Security.Cryptography.CryptographicException ce)
			{
				privateKeyIsExportable = false;
				_privateKeyFileName = ce.Message;
			}
		}
		else
		{
			privateKeyIsExportable = false;
			_privateKeyFileName = String.Empty;
		}

		foreach (X509Extension ext in certificate.Extensions)
		{
            if (ext is X509BasicConstraintsExtension constraintExt)
            {
                _extensionIsCACert = constraintExt.CertificateAuthority;
                break;
            }
        }

		_privKeyDataFilled = true;
	}

	private static RSACryptoServiceProvider PrivateKey(X509Certificate2 certificate)
    {
		// TODO
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
        if (privateKey == null)
        {
            return "Private key does not exist or is not accessible";
        }

		try
        {
			string keyFileName = privateKey.CspKeyContainerInfo.UniqueKeyContainerName;
			string keyDirectory = null;

			#region Determine keyDirectory

			// Look up All User profile from environment variable
			string machineKeyDir = string.Format(@"{0}\Microsoft\Crypto\RSA\MachineKeys",
			    Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));

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

			StringBuilder sb = new();
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
            var c = GetX509Certificate2ClientWillCallReset();
            var b = c.Export(c.HasExportablePrivateKey() ?
                X509ContentType.Pfx : X509ContentType.Cert);
            c.Reset();

            var result = new XStreamingElement("Certificate",
                new XAttribute("StoreName", StoreNameAsString),
                new XAttribute("StoreLocation",
                    Enum.GetName(typeof(StoreLocation), StoreLocation)),
                new XText(Convert.ToBase64String(b)));

            return result;
        }

        public CertData(XElement e)
        {
            string storeName = e.Attribute("StoreName").Value;
            StoreLocation storeLocation = (StoreLocation) Enum.Parse(
                typeof(StoreLocation), e.Attribute("StoreLocation").Value);
            m_transientCert = Convert.FromBase64String(e.Value);
            X509Certificate2 certificate = new(m_transientCert);

            FillCheapCertData(storeLocation, storeName, certificate);
            FillKeyIndentifierCertData(certificate);
            FillPrivKeyCertData(certificate);
        }

        internal bool NotYetInStore
        {
            get
            {
                using X509Store store = new(StoreNameAsString, StoreLocation);
                try
                {
                    store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

                    foreach (X509Certificate2 cert in store.Certificates)
                    {
                        if (CanReplaceStoreCert(cert))
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
                    store?.Close();
                }
            }
        }

        private bool CanReplaceStoreCert(X509Certificate2 storeCertificate)
        {
            return
                !storeCertificate.Subject.Equals(CertSubject) ||
                !storeCertificate.Issuer.Equals(CertIssuer) ||
                !storeCertificate.Thumbprint.Equals(CertThumbprint) ||
                !storeCertificate.SerialNumber.Equals(CertSerialNumber) ||
                !storeCertificate.NotBefore.Equals(CertNotBefore) ||
                !storeCertificate.NotAfter.Equals(CertNotAfter) ||
                (
                    !storeCertificate.HasPrivateKey &&
                    CertHasPrivateKey
                );
        }

        internal void Install()
        {
            if (NotYetInStore)
            {
                using X509Store s = new(StoreNameAsString, StoreLocation);
                try
                {
                    s.Open(OpenFlags.ReadWrite);

                    var cert = GetX509Certificate2ClientWillCallReset();

                    s.Add(cert);
                }
                finally
                {
                    s.Close();
                }
            }
        }
    }