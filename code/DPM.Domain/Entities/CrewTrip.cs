using DPM.Domain.Common.Models;
using DPM.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Domain.Entities
{
    public class CrewTrip : BaseEntity
    {
        public string? TripId { get; set; }
        public virtual RegisterToDeparture? RegisterToDeparture { get; set; }
        public virtual RegisterToArrival? RegisterToArrival { get; set; }
        public long CrewId { get; set; }
        public virtual Crew? Crew { get; set; } 
    }
}
