using DevExpress.Pdf;
using DPM.Applications.Services;
using DPM.Domain.Common.Models;
using DPM.Infrastructure.Common.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;

namespace DPM.Infrastructure.Providers.DevExpress
{
    public class DigitalSigningService : IDigitalSigningService
    {
        public class Options
        {
            public static readonly string SectionName = "DigitalSign";

            [Required]
            public string TimestampServerUrl { get; set; } = default!;
            [Required]
            public string Certificate { get; set; } = default!;
            public string Secret { get; set; } = default!;
        }

        private readonly Options _options;

        private readonly IStorageService _storageService;

        public DigitalSigningService(IOptionsSnapshot<Options> options,  IStorageService storageService)
        {
            _options = options.Value;
            _storageService = storageService;
        }

        public async Task<bool> SignAsync(byte[] documentContent, string objectKey, Domain.Common.Models.PdfSignature signatures)
        {
            try
            {
                var timestampServerUrl = _options.TimestampServerUrl;
                var certificate = await _storageService.DownloadAsync(_options.Certificate);
                var secret = _options.Secret;

                using (var memoryStream = new MemoryStream(documentContent))
                {
                    await Task.Run(() =>
                    {
                        using (var signer = new PdfDocumentSigner(memoryStream))
                        {
                            using (var outputStream = new MemoryStream())
                            {
                                var signatureFieldInfo = DigitalSignatureExtension.GetSignatureFieldInfo(signatures);
                                var digitalSignatureBuilder = DigitalSignatureExtension.GetSignatureBuilders(signatures, timestampServerUrl, certificate, secret, signatureFieldInfo);
                                var signatureAppearance = DigitalSignatureExtension.GetSignatureAppearance(signatures.ImageData);
                                digitalSignatureBuilder.SetSignatureAppearance(signatureAppearance);
                                signer.SaveDocument(outputStream, digitalSignatureBuilder);
                                var file = outputStream.ToArray();
                                _storageService.UploadStreamAsync(file, objectKey);
                            }
                        }
                    });
                }

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
