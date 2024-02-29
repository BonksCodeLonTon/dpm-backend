using DPM.Domain.Common.Models;
using DPM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Domain.Entities
{
    public class FishingTrip : BaseEntity, IAuditableEntity, ISoftDeletableEntity
    {
        public long ShipId { get; set; }
        public Ship? Ship { get; set; }
        public ICollection<Fishermen>? Crews { get; set;}
        public TripStatus TripStatus { get; set; }
        public ShipStatus ShipStatus { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public User? Creator { get; set; }
        public User? Updater { get; set; }
        public bool IsDeleted { get => ((ISoftDeletableEntity)Ship).IsDeleted; set => ((ISoftDeletableEntity)Ship).IsDeleted = value; }
    }
}
