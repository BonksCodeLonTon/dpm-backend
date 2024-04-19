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
        private readonly ICrewTripRepository _crewTripRepository;
        private readonly ICrewRepository _crewRepository;

        public GetArrivalRegistrationByIdQueryHandler(
            IRegisterArrivalRepository registerArrivalRepository,
            ICrewTripRepository crewTripRepository,
            ICrewRepository crewRepository)
        {
            _registerArrivalRepository = registerArrivalRepository;
            _crewTripRepository = crewTripRepository;
            _crewRepository = crewRepository;
        }

        public Task<ArrivalRegistration> Handle(GetArrivalRegistrationByIdQuery request, CancellationToken cancellationToken)
        {
            string[] relations = new string[] { "Ship", "Port", "Captain"};
            var crewTrips = _crewTripRepository.GetAll();
            List<Crew> crews = new List<Crew>();
            var arrivalRegistration =  _registerArrivalRepository.GetByStringId(request.Id, tracking: true, relations: relations);
            var crewTrip = crewTrips.FirstOrDefault(ct => ct.TripId == arrivalRegistration.ArrivalId);
            if (crewTrip != null)
            {
                foreach (var crewId in crewTrip.CrewIds)
                {
                    var crew = _crewRepository.GetById(crewId);
                    crews.Add(crew);
                }
                arrivalRegistration.Crews = crews;
            }
            return Task.FromResult(arrivalRegistration);
        }
    }
}
