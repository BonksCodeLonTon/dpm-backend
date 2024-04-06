using AutoMapper;
using DPM.Domain.Common.Interfaces;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DPM.Applications.Features.SailingRegister.GetArrivalRegistrationById
{
    internal class GetArrivalRegistrationByIdQueryHandler : IRequestHandler<GetArrivalRegistrationByIdQuery, ArrivalRegistration>
    {
        private readonly IRegisterArrivalRepository _registerArrivalRepository;

        public GetArrivalRegistrationByIdQueryHandler(IRegisterArrivalRepository registerArrivalRepository)
        {
            _registerArrivalRepository = registerArrivalRepository;
        }

        public Task<ArrivalRegistration> Handle(GetArrivalRegistrationByIdQuery request, CancellationToken cancellationToken)
        {
            var arrivalRegistration =  _registerArrivalRepository.GetByStringId(request.Id);
            return Task.FromResult(arrivalRegistration);
        }
    }
}
