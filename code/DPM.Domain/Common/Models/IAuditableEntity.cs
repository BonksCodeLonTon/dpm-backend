using DPM.Domain.Entities;

namespace DPM.Domain.Common.Models
{
    public interface IAuditableEntity
    {
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public User? Creator { get; set; }
        public User? Updater { get; set; }
    }
}