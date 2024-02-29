using DPM.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Domain.Entities
{
    public class FishingTripHistory : BaseEntity
    {
        public long FishingTripId { get; set; }
        public FishingTrip? FishingTrip { get; set; }
        public Fishermen Fishermen { get; set; }
        public long FishermenId { get; set; }

    }
}
