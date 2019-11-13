using System;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace TroquelApi.Helpers
{
    public class ConnectionString
    {
        private readonly CloudStorage _cloudStorage;
        static string account;
        static string key;

        public ConnectionString(IOptions<CloudStorage> cloudstorage)
        {
            _cloudStorage = cloudstorage.Value;
            account = _cloudStorage.StorageAccountName;
            key = _cloudStorage.StorageAccountKey;
        }

        public static CloudStorageAccount GetConnectionString()
        {
            string connectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", account, key);
            return CloudStorageAccount.Parse(connectionString);
        }
    }
}
