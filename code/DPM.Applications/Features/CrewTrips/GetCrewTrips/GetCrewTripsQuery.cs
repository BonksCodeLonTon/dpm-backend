using DPM.Domain.Entities;
using MediatR;

namespace DPM.Applications.Features.CrewTrips
{
    public class GetCrewTripsQuery : IRequest<IQueryable<CrewTrip>>
    {
    }
}
