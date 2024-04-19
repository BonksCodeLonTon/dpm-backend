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
        private readonly ICrewTripRepository _crewTripRepository;
        private readonly ICrewRepository _crewRepository;
        public GetDepartureRegistrationByIdQueryHandler(
            IRegisterDepartureRepository registerDepartureRepository,
            ICrewTripRepository crewTripRepository,
            ICrewRepository crewRepository)
        {
            _registerDepartureRepository = registerDepartureRepository;
            _crewTripRepository = crewTripRepository;
            _crewRepository = crewRepository;
        }
        public Task<DepartureRegistration> Handle(GetDepartureRegistrationByIdQuery request, CancellationToken cancellationToken)
        {
            string[] relations = new string[] { "Ship", "Port", "Captain" };
            var crewTrips = _crewTripRepository.GetAll();
            List<Crew> crews = new List<Crew>();

            var departureRegistration = _registerDepartureRepository.GetByStringId(request.Id, tracking: true, relations: relations);
            var crewTrip = crewTrips.FirstOrDefault(ct => ct.TripId == departureRegistration.DepartureId);
            if (crewTrip != null)
            {
                foreach (var crewId in crewTrip.CrewIds)
                {
                    var crew = _crewRepository.GetById(crewId);
                    crews.Add(crew);

                }
                departureRegistration.Crews = crews;
            }
            return Task.FromResult(departureRegistration);
        }
    }
}
