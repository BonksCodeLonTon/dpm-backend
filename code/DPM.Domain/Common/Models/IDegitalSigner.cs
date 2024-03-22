namespace DPM.Domain.Common.Models
{
    public interface IDegitalSigner
    {
        void Sign(string documentPath, PdfSignature signatures);
    }
}