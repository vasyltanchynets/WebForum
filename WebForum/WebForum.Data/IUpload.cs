using Microsoft.WindowsAzure.Storage.Blob;

namespace WebForum.Data
{
    public interface IUpload
    {
        CloudBlobContainer GetBlobContainer(string connectionString);
    }
}
