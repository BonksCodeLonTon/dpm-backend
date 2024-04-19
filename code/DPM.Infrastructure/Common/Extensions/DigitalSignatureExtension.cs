using DevExpress.Office.DigitalSignatures;
using DevExpress.Office.Tsp;
using DevExpress.Pdf;
namespace DPM.Infrastructure.Common.Extensions
{
    public class DigitalSignatureExtension
    {
        public static PdfSignatureFieldInfo GetSignatureFieldInfo(Domain.Common.Models.PdfSignature signature)
        {
            return new PdfSignatureFieldInfo(1)
            {
                Name = signature.FieldName,
                SignatureBounds = signature.Location
            };
        }
        public static PdfSignatureBuilder GetSignatureBuilders(Domain.Common.Models.PdfSignature signature, string timeStampUrl, Stream certificate, string secret, PdfSignatureFieldInfo signatureFieldInfo)
        {
            ITsaClient tsaClient = new TsaClient(new Uri(timeStampUrl), HashAlgorithmType.SHA256);

            Pkcs7Signer pkcs7Signature = new Pkcs7Signer(certificate, secret, HashAlgorithmType.SHA256, tsaClient, null, null, PdfSignatureProfile.PAdES_BES);

            var signatureBuilder = new PdfSignatureBuilder(pkcs7Signature, signatureFieldInfo);

            signatureBuilder.Location = "Đà Nẵng, Việt Nam";
            signatureBuilder.Name = signature.FullName;
            signatureBuilder.Reason = signature.Reason;

            return signatureBuilder;
        }
        public static PdfSignatureAppearance GetSignatureAppearance(byte[] imageData)
        {
            return new PdfSignatureAppearance()
            {
                ShowLocation = true,
                ShowDate = true,
                DateTimeFormat = "dd/MM/yyyy",
                ShowReason = true,
                
            };
        }
    }
}