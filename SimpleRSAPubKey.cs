namespace X509CertificateTool;

using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

internal class SimpleRSAPubKey
{
	string modulus;
	string exponent;

        private SimpleRSAPubKey() { }

	internal SimpleRSAPubKey(X509Certificate2 cert)
	{
		AsymmetricAlgorithm key = cert.PublicKey.Key;
		string keyAsXml = key.ToXmlString(false);

		modulus = GetModulus(keyAsXml);
		exponent = GetExponent(keyAsXml);
	}

	internal bool EqualsKeyXml(string keyAsXml)
	{
		string otherModulus = GetModulus(keyAsXml);
		if (!modulus.Equals(otherModulus))
		{
			return false;
		}

		string otherExponent = GetExponent(keyAsXml);
		return exponent.Equals(otherExponent);
	}

	static string GetModulus(string keyAsXml)
	{
		return GetCryptoValue("Modulus", keyAsXml);
	}

	static string GetExponent(string keyAsXml)
	{
		return GetCryptoValue("Exponent", keyAsXml);
	}

	static string GetCryptoValue(string localName, string keyAsXml)
	{
		//string modStart = String.Format("<{0}>", localName);
		//string modEnd = String.Format("</{0}>", localName);
		//int modStartI = keyAsXml.IndexOf(modStart) + modStart.Length;
		//int modEndI = keyAsXml.IndexOf(modEnd);
		//return keyAsXml.Substring(modStartI, modEndI - modStartI);

		string regexStr = string.Format(@"<(\S+:)?{0}>(.*)</(\S+:)?{0}>", localName);
		string match = Regex.Match(keyAsXml, regexStr).Groups[2].Value;

		return match;
	}

	public override string ToString() =>
		$"""
		<RSAKeyValue xmlns=\"http://www.w3.org/2000/09/xmldsig#\">
			<Modulus>{modulus}</Modulus>
			<Exponent>{exponent}</Exponent>
		</RSAKeyValue>
		""";

	public static string CanonicalizeKey(string someKeyXml)
	{
            SimpleRSAPubKey newKey = new()
            {
                exponent = GetExponent(someKeyXml),
                modulus = GetModulus(someKeyXml)
            };
            return newKey.ToString();
	}
}
