using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Security.Cryptography;

namespace SecIntelSample
{
    // Azure Storage Samples

    public class AzureStorageSample
    {
        // Storage account SAS Token creation samples
        public static string GetAccountSASToken()
        {
            const string ConnectionString =
                "DefaultEndpointsProtocol=https;AccountName=account-name;AccountKey=account-key";
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConnectionString);

            // Sample in which error is generated due to usage of insecure [HttpsOrHttp] protocol configuration

            SharedAccessAccountPolicy policy = new SharedAccessAccountPolicy
            {
                Permissions =
                    SharedAccessAccountPermissions.Read | SharedAccessAccountPermissions.Write |
                    SharedAccessAccountPermissions.List,
                Services = SharedAccessAccountServices.Blob | SharedAccessAccountServices.File,
                ResourceTypes = SharedAccessAccountResourceTypes.Service,
                SharedAccessExpiryTime = DateTime.UtcNow.AddHours(24),
                Protocols = SharedAccessProtocol.HttpsOnly
            };

            // Sample in which warning is generated to be aware of expiry time [SharedAccessExpiryTime]

            policy = new SharedAccessAccountPolicy
            {
                Permissions =
                    SharedAccessAccountPermissions.Read | SharedAccessAccountPermissions.Write |
                    SharedAccessAccountPermissions.List,
                Services = SharedAccessAccountServices.Blob | SharedAccessAccountServices.File,
                ResourceTypes = SharedAccessAccountResourceTypes.Service,
                SharedAccessExpiryTime = DateTime.UtcNow.AddHours(24),
                Protocols = SharedAccessProtocol.HttpsOnly,
            };

            return storageAccount.GetSharedAccessSignature(policy);
        }

        // Rule ID: azure_storage_sastoken_validity_too_long

        public static string GetAccountSASTokenWarnAboutExpiry()
        {
            const string ConnectionString =
                "DefaultEndpointsProtocol=https;AccountName=account-name;AccountKey=account-key";
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConnectionString);

            // Sample in which warning is generated to be aware of expiry time [SharedAccessExpiryTime]

            SharedAccessAccountPolicy policy = new SharedAccessAccountPolicy
            {
                Permissions =
                    SharedAccessAccountPermissions.Read | SharedAccessAccountPermissions.Write |
                    SharedAccessAccountPermissions.List,
                Services = SharedAccessAccountServices.Blob | SharedAccessAccountServices.File,
                ResourceTypes = SharedAccessAccountResourceTypes.Service,
                SharedAccessExpiryTime = DateTime.UtcNow.AddHours(24),
                Protocols = SharedAccessProtocol.HttpsOnly,
            };
            return storageAccount.GetSharedAccessSignature(policy);
        }

        // Rule ID: azure_storate_sas_use_https

        public static string GetAccountSASTokenErrorAboutInsecureProtocol()
        {
            const string ConnectionString =
                "DefaultEndpointsProtocol=https;AccountName=account-name;AccountKey=account-key";
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConnectionString);

            // Sample in which error is generated due to usage of insecure [HttpsOrHttp] protocol configuration

            SharedAccessAccountPolicy policy = new SharedAccessAccountPolicy
            {
                Permissions =
                    SharedAccessAccountPermissions.Read | SharedAccessAccountPermissions.Write |
                    SharedAccessAccountPermissions.List,
                Services = SharedAccessAccountServices.Blob | SharedAccessAccountServices.File,
                ResourceTypes = SharedAccessAccountResourceTypes.Service,
                SharedAccessExpiryTime = DateTime.UtcNow.AddHours(24),
                Protocols = SharedAccessProtocol.HttpsOrHttp
            };
            return storageAccount.GetSharedAccessSignature(policy);
        }


        // Storage account Blob container creation samples
        public static void CreateBlobContainer()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("");
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("mycontainer");
            container.CreateIfNotExists();

            // Sample in which warning is generated to be aware of container access policy

            container.SetPermissions(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            // Sample in which warning is generated to be aware of container access policy

            container.SetPermissions(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Container
            });

            // Sample in which most restricted access type is used

            container.SetPermissions(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Off
            });
            RNGCryptoServiceProvider rnd = new RNGCryptoServiceProvider();
        }

        // Rule ID: azure_storage_blob_public_access
        public static void CreateBlobContainerBlobAccessType()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("");
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("mycontainer");
            container.CreateIfNotExists();

            // Sample in which warning is generated to be aware of container access policy

            container.SetPermissions(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
        }

        // Rule ID: azure_storage_container_public_access
        public static void CreateBlobContainerPublicAccessType()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("");
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("mycontainer");
            container.CreateIfNotExists();

            // Sample in which warning is generated to be aware of container access policy

            container.SetPermissions(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Container
            });
        }
    }
}