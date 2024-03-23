using DPM.Domain.Common.Models;

namespace DPM.Domain.Entities
{
    public class Port : BaseEntity, IAuditableEntity
    {
        public string? Name { get; set; }
        public long? CreatedBy { get; set;}
        public long? UpdatedBy { get; set; }
        public User? Creator { get; set; }
        public User? Updater { get; set; }
    }
}
