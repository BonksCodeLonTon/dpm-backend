using PdfSignature = DPM.Domain.Common.Models.PdfSignature;
namespace DPM.Applications.Services
{
    public interface IDigitalSigningService
    {
        Task<bool> SignAsync(byte[] documentContent, string objectKey, PdfSignature signatures);
    }
}
