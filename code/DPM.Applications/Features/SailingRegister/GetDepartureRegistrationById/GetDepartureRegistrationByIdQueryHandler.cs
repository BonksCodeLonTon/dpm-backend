using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.SailingRegister.GetDepartureRegistrationById
{
    internal class GetDepartureRegistrationByIdQueryHandler : IRequestHandler<GetDepartureRegistrationByIdQuery, DepartureRegistration>
    {
        private readonly IRegisterDepartureRepository _registerDepartureRepository;

        public GetDepartureRegistrationByIdQueryHandler(IRegisterDepartureRepository registerDepartureRepository)
        {
            _registerDepartureRepository = registerDepartureRepository;
        }

        public Task<DepartureRegistration> Handle(GetDepartureRegistrationByIdQuery request, CancellationToken cancellationToken)
        {
            var arrivalRegistration = _registerDepartureRepository.GetByStringId(request.Id);
            return Task.FromResult(arrivalRegistration);
        }
    }
}
