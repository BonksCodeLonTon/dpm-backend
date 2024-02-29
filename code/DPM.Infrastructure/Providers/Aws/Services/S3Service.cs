using Amazon.S3;
using Amazon.S3.Model;
using DPM.Applications.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Expires = System.DateTime.Now.AddMinutes(15),
                Verb = HttpVerb.PUT,
                ContentType = type,
                Headers =
        {
          ContentLength = size
        }
            };

            return _s3Client.GetPreSignedURL(request);
        }

        public string GetUrl(string objectKey)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = BucketName,
                Key = objectKey,
                Expires = System.DateTime.Now.AddMinutes(5),
                Verb = HttpVerb.GET
            };

            return _s3Client.GetPreSignedURL(request);
        }
    }

}
