using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;

namespace DPM.Applications.Features.MilitaryUsers.MilitaryDepartReject
{
    internal class MilitaryDepartRejectCommandHandler : IRequestHandler< MilitaryDepartRejectCommand, bool>
    {
        private readonly IRequestContextService _requestContextService;
        private readonly IRegisterDepartureRepository _registerDepartureRepository;

        public MilitaryDepartRejectCommandHandler(
          IRequestContextService requestContextService,
          IRegisterDepartureRepository registerDepartureRepository
            )
        {
            _requestContextService = requestContextService;
            _registerDepartureRepository = registerDepartureRepository;
        }

        public async Task<bool> Handle( MilitaryDepartRejectCommand request, CancellationToken cancellationToken)
        {
            var departRegistration = _registerDepartureRepository.
                GetAll(tracking: true)
               .FirstOrDefault(u => u.DepartureId == request.DepartureId) ?? throw new NotFoundException(nameof(DepartureRegistration));
            departRegistration.ApproveStatus = Domain.Enums.ApproveStatus.RejectedByMilitary;

            await _registerDepartureRepository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
