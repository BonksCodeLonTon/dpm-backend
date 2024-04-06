using DPM.Domain.Common.Models;
using DPM.Domain.Enums;


namespace DPM.Domain.Entities
{
    public class Crew : BaseEntity, IAuditableEntity
    {
        public string? Fullname { get; set; }
        public Countries Countries { get; set; }
        public string? NationalId { get; set; }
        public string? YearExperience {  get; set; }
        public string? RelativePhoneNumber { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set;  }
        public User? Creator { get; set; }
        public User? Updater { get; set; }
    }
}
