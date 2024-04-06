using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;

namespace DPM.Applications.Features.PortAuthorityUsers.PortAuthorityDepartApprove
{
    internal class PortAuthorityDepartApproveCommandHandler : IRequestHandler<PortAuthorityDepartApproveCommand, bool>
    {
        private readonly IRequestContextService _requestContextService;
        private readonly IRegisterDepartureRepository _registerDepartureRepository;

        public PortAuthorityDepartApproveCommandHandler(
          IRequestContextService requestContextService,
          IRegisterDepartureRepository registerDepartureRepository
            )
        {
            _requestContextService = requestContextService;
            _registerDepartureRepository = registerDepartureRepository;
        }

        public async Task<bool> Handle(PortAuthorityDepartApproveCommand request, CancellationToken cancellationToken)
        {
            var departRegistration = _registerDepartureRepository.
                GetAll(tracking: true)
               .FirstOrDefault(u => u.DepartureId == request.DepartureId) ?? throw new NotFoundException(nameof(DepartureRegistration));
            departRegistration.ApproveStatus = Domain.Enums.ApproveStatus.ApprovedByPortAuthority;

            await _registerDepartureRepository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
