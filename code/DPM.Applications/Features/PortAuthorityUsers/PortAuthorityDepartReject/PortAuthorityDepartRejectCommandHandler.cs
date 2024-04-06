
using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;

namespace DPM.Applications.Features.PortAuthorityUsers.PortAuthorityDepartReject
{
    internal class PortAuthorityDepartRejectCommandHandler : IRequestHandler<PortAuthorityDepartRejectCommand, bool>
    {
        private readonly IRequestContextService _requestContextService;
        private readonly IRegisterDepartureRepository _registerDepartureRepository;

        public PortAuthorityDepartRejectCommandHandler(
          IRequestContextService requestContextService,
          IRegisterDepartureRepository registerDepartureRepository
            )
        {
            _requestContextService = requestContextService;
            _registerDepartureRepository = registerDepartureRepository;
        }

        public async Task<bool> Handle(PortAuthorityDepartRejectCommand request, CancellationToken cancellationToken)
        {
            var departureRegistration = _registerDepartureRepository.
                GetAll(tracking: true)
               .FirstOrDefault(u => u.DepartureId == request.DepartureId) ?? throw new NotFoundException(nameof(DepartureRegistration));
            departureRegistration.ApproveStatus = Domain.Enums.ApproveStatus.RejectedByPortAuthority;

            await _registerDepartureRepository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
