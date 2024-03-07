using DPM.Domain.Common.Models;
using DPM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Domain.Entities
{
    public class Crew : BaseEntity, IAuditableEntity
    {
        public string? Fullname { get; set; }
        public Countries Countries { get; set; }
        public string? NationalId { get; set; }
        public DateTime? YearExperience {  get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set;  }
        public User? Creator { get; set; }
        public User? Updater { get; set; }
    }
}
