using DPM.Domain.Common.Models;
using DPM.Domain.Enums;

namespace DPM.Domain.Entities
{
    public class Ship : BaseEntity, ISoftDeletableEntity, IAuditableEntity
    {
        public string? Name { get; set; }
        public string? ClassNumber { get; set; }
        public string? IMONumber { get; set; }
        public string? RegisterNumber {get; set; }
        public string? GrossTonnage { get; set; }
        public ShipType ShipType { get; set; }
        public ShipStatus ShipStatus { get; set; }
        public string? TotalPower { get; set; }
        public long? OwnerId { get; set; }
        public User? Owner { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public User? Creator { get; set; }
        public User? Updater { get; set; }

    }
}
