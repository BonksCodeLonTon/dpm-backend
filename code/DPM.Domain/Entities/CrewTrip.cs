using DPM.Domain.Common.Models;

namespace DPM.Domain.Entities
{
    public class CrewTrip : BaseEntity
    {
        public string? TripId { get; set; }
        public virtual DepartureRegistration? RegisterToDeparture { get; set; }
        public virtual ArrivalRegistration? RegisterToArrival { get; set; }
        public long[] CrewIds { get; set; }
        public virtual List<Crew>? Crew { get; set; } 
    }
}
