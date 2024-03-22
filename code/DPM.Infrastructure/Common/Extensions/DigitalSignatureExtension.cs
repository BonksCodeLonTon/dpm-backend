using DevExpress.Office.DigitalSignatures;
using DevExpress.Office.Tsp;
using DevExpress.Pdf;

namespace DPM.Infrastructure.Common.Extensions
{
    public class DigitalSignatureExtension
    {
        public static PdfSignatureBuilder GetSignatureBuilders(Domain.Common.Models.PdfSignature signature, string timeStampUrl, string certificate, string secret)
        {
            ITsaClient tsaClient = new TsaClient(new Uri(timeStampUrl), HashAlgorithmType.SHA256);

            Pkcs7Signer pkcs7Signature = new Pkcs7Signer(certificate, secret, HashAlgorithmType.SHA256, tsaClient, null, null, PdfSignatureProfile.PAdES_BES);

            var signatureBuilder = new PdfSignatureBuilder(pkcs7Signature);

            signatureBuilder.SetImageData(signature.ImageData);
            signatureBuilder.Location = signature.Location;
            signatureBuilder.Name = signature.Name;
            signatureBuilder.Reason = signature.Reason;

            return signatureBuilder;
        }
    }
}