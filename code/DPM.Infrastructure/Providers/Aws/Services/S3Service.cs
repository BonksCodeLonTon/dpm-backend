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

        public async Task<byte[]> GetObject(string objectKey)
        {
            try
            {
                GetObjectResponse response = _s3Client.GetObjectAsync(new GetObjectRequest
                {
                    BucketName = BucketName,
                    Key = objectKey
                }).Result;
                using (var stream = response.ResponseStream)
                {
                    var memoryStream = new MemoryStream();
                    await stream.CopyToAsync(memoryStream);
                    return memoryStream.ToArray();
                }
            }
            catch (AmazonS3Exception ex)
            {
                throw new Exception($"Error downloading object '{objectKey}' from S3", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error downloading object '{objectKey}' from S3", ex);
            }

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
        public async Task<bool> UploadStreamAsync(byte[] file, string objectKey)
        {
            try
            {
                var fileTransferUtility = new TransferUtility(_s3Client);
                var fileTransferUtilityRequest = new TransferUtilityUploadRequest
                {
                    BucketName = BucketName,
                    StorageClass = S3StorageClass.Standard,
                    PartSize = 6291456,
                    CannedACL = S3CannedACL.NoACL,
                    Key = objectKey
                };
                using (var stream = new MemoryStream(file))
                {
                    fileTransferUtilityRequest.InputStream = stream;
                    await fileTransferUtility.UploadAsync(stream, BucketName, objectKey);

                }


                return true;
            }
            catch (AmazonS3Exception ex)
            {
                throw new Exception($"Error uploading object to S3: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error uploading object to S3: {ex.Message}", ex);
            }
        }

        public async Task<Stream> DownloadAsync(string objectKey)
        {
            try
            {
                GetObjectResponse response = await _s3Client.GetObjectAsync(new GetObjectRequest
                {
                    BucketName = BucketName,
                    Key = objectKey
                });

                MemoryStream memStream = new MemoryStream();
                using (Stream responseStream = response.ResponseStream)
                {
                    await responseStream.CopyToAsync(memStream);
                    memStream.Seek(0, SeekOrigin.Begin);
                }

                return memStream;
            }
            catch (AmazonS3Exception ex)
            {
                throw new Exception($"Error downloading object '{objectKey}' from S3", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error downloading object '{objectKey}' from S3", ex);
            }
        }

    }
}
