using DPM.Domain.Entities;
using MediatR;

namespace DPM.Applications.Features.CrewTrips.GetStartCrewTrips
{
    public class GetStartCrewTripsQuery : IRequest<IQueryable<CrewTrip>>
    {
    }
}
