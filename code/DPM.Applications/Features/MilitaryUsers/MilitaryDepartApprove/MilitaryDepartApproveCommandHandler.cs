using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;

namespace DPM.Applications.Features.MilitaryUsers.MilitaryDepartApprove
{
    public class MilitaryDepartApproveCommandHandler : IRequestHandler<MilitaryDepartApproveCommand, bool>
    {
        private readonly IRequestContextService _requestContextService;
        private readonly IRegisterDepartureRepository _registerDepartureRepository;
        private readonly IDigitalSigningService _digitalSigningService;
        private readonly IStorageService _storageService;

        public MilitaryDepartApproveCommandHandler(
          IRequestContextService requestContextService,
          IRegisterDepartureRepository registerDepartureRepository,
          IDigitalSigningService digitalSigningService,
          IStorageService storageService
            )
        {
            _requestContextService = requestContextService;
            _registerDepartureRepository = registerDepartureRepository;
            _digitalSigningService = digitalSigningService;
            _storageService = storageService;
        }

        public async Task<bool> Handle(MilitaryDepartApproveCommand request, CancellationToken cancellationToken)
        {
            var departRegistrationUrl = _storageService.GetUrl(request.Path);
            var departRegistration = _registerDepartureRepository.              
                GetAll(tracking: true)
               .FirstOrDefault(u => u.DepartureId == request.DepartureId) ?? throw new NotFoundException(nameof(DepartureRegistration));
            departRegistration.ApproveStatus = Domain.Enums.ApproveStatus.ApprovedByMilitary;

            await _registerDepartureRepository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
