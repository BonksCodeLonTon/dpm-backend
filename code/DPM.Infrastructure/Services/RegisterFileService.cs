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

        public string GenerateRegisterArrivalFile(string objectKey)
        {
            var arrivalTemplate = _storageService.GetObject(objectKey);
            return arrivalTemplate;
        }

        public string GenerateRegisterDepartureFile(string objectKey)
        {
            var departureTemplate = _storageService.GetObject(objectKey);
            return departureTemplate;
        }
    }
}