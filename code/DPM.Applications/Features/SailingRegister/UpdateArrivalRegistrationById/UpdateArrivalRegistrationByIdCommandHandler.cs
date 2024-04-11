using AutoMapper;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;

namespace DPM.Applications.Features.SailingRegister.UpdateArrivalRegistrationById
{
    internal class UpdateArrivalRegistrationByIdCommandHandler : IRequestHandler<UpdateArrivalRegistrationByIdCommand, bool>
    {
        private readonly IRegisterArrivalRepository _registerArrivalRepository;
        public UpdateArrivalRegistrationByIdCommandHandler(IRegisterArrivalRepository registerArrivalRepository)
        {
            _registerArrivalRepository = registerArrivalRepository;
        }

        public async Task<bool> Handle(UpdateArrivalRegistrationByIdCommand request, CancellationToken cancellationToken)
        {
            var arrivalRegistration = _registerArrivalRepository.GetByStringId(request.ArrivalId, tracking: true)
                    ?? throw new NotFoundException(nameof(ArrivalRegistration));
            arrivalRegistration.Attachment = request.Attachment;

            await _registerArrivalRepository.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
