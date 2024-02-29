using DPM.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Domain.Entities
{
    public class Fishermen : BaseEntity
    {
        public long UserId { get; set; }
        public long YearExperience { get; set; }
        [NotMapped]
        public ICollection<FishingTripHistory>? FishingTripHistories { get; set; }
        public User? User { get; set; }
    }
}
