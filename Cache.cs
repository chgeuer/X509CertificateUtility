namespace X509CertificateTool;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// Caches certificate information.
/// </summary>
internal static class Cache
{
    private static Dictionary<StoreLocation, Dictionary<string, Collection<CertData>>> _cache;

    internal static Collection<CertData> GetCachedData(
        StoreLocation storeLocation,
        string storeNameAsString,
        bool computeKeyIdentifiersImmediately,
        bool computePrivateKeyDataImmediately)
    {
        Cache.FillCache(
            storeLocation, storeNameAsString,
            computeKeyIdentifiersImmediately,
            computePrivateKeyDataImmediately);

        return _cache[storeLocation][storeNameAsString];
    }

    internal static void Clear()
    {
        if (_cache == null)
        {
            return;
        }

        foreach (StoreLocation storeLocation in _cache.Keys)
        {
            foreach (string storeName in _cache[storeLocation].Keys)
            {
                _cache[storeLocation][storeName].Clear();
            }
        }
    }

    private static void FillCache(
        StoreLocation storeLocation,
        string storeNameAsString,
        bool computeKeyIdentifiersImmediately,
        bool computePrivateKeyDataImmediately)
    {
        if (_cache == null)
        {
            _cache = new Dictionary<StoreLocation, Dictionary<string, Collection<CertData>>>();
        }

        if (!_cache.ContainsKey(storeLocation))
        {
            _cache[storeLocation] = [];
        }
        Dictionary<string, Collection<CertData>> cacheLevel2 = _cache[storeLocation];

        if (!cacheLevel2.ContainsKey(storeNameAsString))
        {
            cacheLevel2[storeNameAsString] = new Collection<CertData>();
        }
        Collection<CertData> cacheLevel3 = cacheLevel2[storeNameAsString];

        X509Store store = new X509Store(storeNameAsString, storeLocation);
        try
        {
            store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);

            // Only do the expensive operation when the number of certs changes
            if (store.Certificates.Count != cacheLevel3.Count)
            {
                cacheLevel3.Clear();

                foreach (X509Certificate2 cert in store.Certificates)
                {
                    cacheLevel3.Add(CertData.FromCert(
                        storeLocation, storeNameAsString, cert,
                        computeKeyIdentifiersImmediately,
                        computePrivateKeyDataImmediately));

                    cert.Reset();
                }
            }
        }
        catch (CryptographicException)
        {
        }
        finally
        {
            store?.Close();
        }
    }
}