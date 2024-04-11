using DPM.Applications.Services;

namespace DPM.Infrastructure.Services
{
    public class RegisterFileService
    {
        private readonly IStorageService _storageService;

        public RegisterFileService(IStorageService storageService)
        {
            _storageService = storageService;
        }
    }
}