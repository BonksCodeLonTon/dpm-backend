using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using DPM.Applications.Services;
using DPM.Infrastructure.Common.Extensions;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace DPM.Infrastructure.Providers.Aws.Services
{
    internal class S3Service : IStorageService
    {
        public class Options
        {
            public const string SectionName = "S3";

            [Required]
            public string BucketName { get; set; } = default!;
        }

        public string BucketName { get; }
        private readonly IAmazonS3 _s3Client;

        public S3Service(IAmazonS3 s3Client, IOptionsSnapshot<Options> options)
        {
            _s3Client = s3Client;
            BucketName = options.Value.BucketName;
        }

        public string GetUploadUrl(string objectKey, string type, long size)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = BucketName,
                Key = objectKey,
                Expires = DateTime.Now.AddMinutes(15),
                Verb = HttpVerb.PUT,
                ContentType = type,
                Headers =
        {
          ContentLength = size
        }
            };

            return _s3Client.GetPreSignedURL(request);
        }

        public string GetObject(string objectKey)
        {
            GetObjectResponse response = _s3Client.GetObjectAsync(new GetObjectRequest
            {
                BucketName = BucketName,
                Key = objectKey
            }).Result;

            return S3Extensions.ReadObjectAsString(response);
        }

        public string GetUrl(string objectKey)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = BucketName,
                Key = objectKey,
                Expires = DateTime.Now.AddMinutes(5),
                Verb = HttpVerb.GET
            };

            return _s3Client.GetPreSignedURL(request);
        }

        public async Task<bool> UploadFileAsync(string filePath, string objectKey, string contentType)
        {
                var fileTransferUtility = new TransferUtility(_s3Client);

                var request = new TransferUtilityUploadRequest
                {
                    BucketName = BucketName,
                    FilePath = filePath,
                    Key = objectKey,
                    ContentType = contentType
                };

                await fileTransferUtility.UploadAsync(request);

                return true;
            }
        }
    }
