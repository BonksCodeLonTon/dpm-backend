using DPM.Domain.Common.Models;

namespace DPM.Domain.Entities
{
    public class CrewTrip : BaseEntity
    {
        public CrewTrip(string tripId, long crewId)
        {
            TripId = tripId;
            CrewId = crewId;
        }

        public string? TripId { get; set; }
        public virtual DepartureRegistration? RegisterToDeparture { get; set; }
        public virtual ArrivalRegistration? RegisterToArrival { get; set; }
        public long CrewId { get; set; }
        public virtual Crew? Crew { get; set; } 
    }
}
