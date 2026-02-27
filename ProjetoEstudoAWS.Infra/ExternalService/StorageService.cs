using Amazon.S3;
using Amazon.S3.Model;

namespace ProjetoEstudoAWS.Infra.ExternalService
{
    public interface IStorageService
    {
        Task<string> GenerateDownloadUrl(string bucket, string key);
        Task<string> GenerateUploadUrl(string bucket, string key);      
    }
}
