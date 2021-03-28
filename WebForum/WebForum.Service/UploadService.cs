using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using WebForum.Data;

namespace WebForum.Service
{
    public class UploadService : IUpload
    {
        public CloudBlobContainer GetBlobContainer(string connectionString)
        {
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();

            return blobClient.GetContainerReference("profile-images");
        }
    }
}
