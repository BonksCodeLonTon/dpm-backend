using System.Runtime.CompilerServices;
using PdfSignature = DPM.Domain.Common.Models.PdfSignature;

namespace DPM.Applications.Services
{
    public interface IDigitalSigningService
    {
        Task<bool> SignAsync(string documentPath, PdfSignature signatures);
    }
}
