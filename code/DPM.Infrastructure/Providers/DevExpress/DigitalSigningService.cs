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
            public static readonly string SectionName = "Sign";

            [Required]
            public string TimestampServerUrl { get; set; } = default!;

            [Required]
            public string Certificate { get; set; } = default!;

            [Required]
            public string Secret { get; set; } = default!;
        }

        private readonly Options _options;

        public DigitalSigningService(IOptionsSnapshot<Options> options)
        {
            _options = options.Value;
        }

        public async Task<bool> SignAsync(string documentPath, Domain.Common.Models.PdfSignature signatures)
        {
            try
            {
                var timestampServerUrl = _options.TimestampServerUrl;
                var certificate = _options.Certificate;
                var secret = _options.Secret;

                string documentName = Path.GetFileName(documentPath);
                string signedDocumentName = $"Signed {documentName}";
                string signedDocumentPath = Path.Combine(Path.GetDirectoryName(documentPath), signedDocumentName);

                await Task.Run(() =>
                {
                    using (var signer = new PdfDocumentSigner(documentPath))
                    {
                        signer.SaveDocument(signedDocumentPath, DigitalSignatureExtension.GetSignatureBuilders(signatures, timestampServerUrl, certificate, secret));
                    }
                });

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
