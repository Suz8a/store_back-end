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
        private readonly string _account;
        private readonly string _key;

        public ConnectionString(IOptions<CloudStorage> cloudstorage)
        {
            _cloudStorage = cloudstorage.Value;
            _account = _cloudStorage.StorageAccountName;
            _key = _cloudStorage.StorageAccountKey;
        }

        public CloudStorageAccount GetConnectionString()
        {

            string connectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", _account, _key);
            return CloudStorageAccount.Parse(connectionString);
        }
    }
}
