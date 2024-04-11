using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;

namespace DPM.Applications.Features.SailingRegister.UpdateDepartureRegistrationById
{
    internal class UpdateDepartureRegistrationByIdCommandHandler : IRequestHandler<UpdateDepartureRegistrationByIdCommand, bool>
    {
        private readonly IRegisterDepartureRepository _registerDepartureRepository;
        public UpdateDepartureRegistrationByIdCommandHandler(IRegisterDepartureRepository registerDepartureRepository)
        {
            _registerDepartureRepository = registerDepartureRepository;
        }

        public async Task<bool> Handle(UpdateDepartureRegistrationByIdCommand request, CancellationToken cancellationToken)
        {
            var arrivalRegistration = _registerDepartureRepository.GetByStringId(request.DepartureId, tracking: true)
                    ?? throw new NotFoundException(nameof(DepartureRegistration));
            arrivalRegistration.Attachment = request.Attachment;

            await _registerDepartureRepository.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
