using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;

namespace DPM.Applications.Features.PortAuthorityUsers.PortAuthorityArriveApprove
{
    internal class PortAuthorityArriveApproveCommandHandler : IRequestHandler<PortAuthorityArriveApproveCommand, bool>
    {
        private readonly IRequestContextService _requestContextService;
        private readonly IRegisterArrivalRepository _registerArrivalRepository;

        public PortAuthorityArriveApproveCommandHandler(
          IRequestContextService requestContextService,
          IRegisterArrivalRepository registerArrivalRepository
            )
        {
            _requestContextService = requestContextService;
            _registerArrivalRepository = registerArrivalRepository;
        }

        public async Task<bool> Handle(PortAuthorityArriveApproveCommand request, CancellationToken cancellationToken)
        {
            var arrivalRegistration = _registerArrivalRepository.
                GetAll(tracking: true)
               .FirstOrDefault(u => u.ArrivalId == request.ArrivalId) ?? throw new NotFoundException(nameof(ArrivalRegistration));
            arrivalRegistration.ApproveStatus = Domain.Enums.ApproveStatus.ApprovedByPortAuthority;

            await _registerArrivalRepository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
