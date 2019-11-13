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

        public ConnectionString(IOptions<CloudStorage> cloudstorage)
        {
            _cloudStorage = cloudstorage.Value;
        }

        static string account = _cloudStorage.StorageAccountName;
        static string key = _cloudStorage.StorageAccountKey;

        public static CloudStorageAccount GetConnectionString()
        {
            string connectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", account, key);
            return CloudStorageAccount.Parse(connectionString);
        }
    }
}
