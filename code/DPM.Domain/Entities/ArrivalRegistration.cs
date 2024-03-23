using DPM.Domain.Common.Models;
using DPM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Domain.Entities
{
    public class ArrivalRegistration : BaseEntity, IAuditableEntity, IRegister
    {
        public string? ArrivalId { get; set; }
        public long ShipId { get; set; }
        public virtual Ship? Ship { get; set; }
        public long PortId { get; set; }
        public virtual Port? Port { get; set; }
        public long CaptainId { get; set; }
        public virtual User? Captain { get; set; }
        public virtual List<Crew> Crews { get; set; }
        public ApproveStatus ApproveStatus { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime ActualArrivalTime { get; set; }
        public string? Attachment { get; set; }
        public string? Note { get; set; }
        public bool IsStart { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public User? Creator { get; set; }
        public User? Updater { get; set; }
    }
}
