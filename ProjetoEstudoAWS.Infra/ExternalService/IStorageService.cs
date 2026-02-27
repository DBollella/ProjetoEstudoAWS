using Amazon.S3;
using Amazon.S3.Model;

namespace ProjetoEstudoAWS.Infra.ExternalService
{
    public class StorageService : IStorageService
    {
        private readonly IAmazonS3 _storageService;

        public StorageService(IAmazonS3 storageService)
        {
            _storageService = storageService;
        }

        public async Task<string> GenerateDownloadUrl(string bucket, string key)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = bucket,
                Key = key,
                Verb = HttpVerb.GET,
                Expires = DateTime.UtcNow.AddMinutes(5)
            };

            var result = await _storageService.GetPreSignedURLAsync(request);

            return result;
        }

        public async Task<string> GenerateUploadUrl(string bucket, string key)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = bucket,
                Key = key,
                Verb = HttpVerb.PUT,
                Expires = DateTime.UtcNow.AddMinutes(10)
            };

            return await _storageService.GetPreSignedURLAsync(request);
        }     
    }
}
