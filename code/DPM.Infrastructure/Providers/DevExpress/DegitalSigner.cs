using DevExpress.Office.DigitalSignatures;
using DevExpress.Office.Tsp;
using DevExpress.Pdf;
using DPM.Domain.Common.Models;
using DPM.Infrastructure.Common;

namespace DPM.Infrastructure.Providers.DevExpress
{
    public class DegitalSigner : IDegitalSigner
    {
        public void Sign(string documentPath, Domain.Common.Models.PdfSignature signatures)
        {
            using (var signer = new PdfDocumentSigner(documentPath))
            {
                string documentName = Path.GetFileName(documentPath);
                string signedDocumentName = $"Signed {documentName}";
                string SignedDocumentPath = Path.Combine(Path.GetDirectoryName(documentPath), signedDocumentName);
                signer.SaveDocument(SignedDocumentPath, GetSignatureBuilders(signatures));
            }
        }

        private PdfSignatureBuilder[] GetSignatureBuilders(Domain.Common.Models.PdfSignature signature)
        {
            var signatureBuilders = new List<PdfSignatureBuilder>();

            ITsaClient tsaClient = new TsaClient(new Uri(Constants.TimestampServerUrl), HashAlgorithmType.SHA256);

            Pkcs7Signer pkcs7Signature = new Pkcs7Signer("", "", HashAlgorithmType.SHA256, tsaClient, null, null, PdfSignatureProfile.PAdES_BES);

            var signatureBuilder = new PdfSignatureBuilder(pkcs7Signature);

            signatureBuilder.SetImageData(signature.ImageData);
            signatureBuilder.Location = signature.Location;
            signatureBuilder.Name = signature.Name;
            signatureBuilder.Reason = signature.Reason;

            signatureBuilders.Add(signatureBuilder); 

            return signatureBuilders.ToArray();
        }
    }
}