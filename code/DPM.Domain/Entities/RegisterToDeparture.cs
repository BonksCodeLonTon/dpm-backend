using DPM.Domain.Common.Models;
using DPM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Domain.Entities
{
    public class RegisterToDeparture : BaseEntity, IAuditableEntity, IRegister
    {
        public string? DepartureId { get; set; }
        public long ShipId { get; set; }
        public virtual Ship? Ship { get; set; }
        public long PortId { get; set; }
        public virtual Port? Port { get; set; }
        public string? Attachment { get; set; }
        public long CaptainId { get; set; }
        public virtual User? Captain { get; set; }
        public virtual long[]? CrewId { get; set; }
        public virtual List<Crew>? Crews { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ActualDepartureTime { get; set; }
        public DateTime GuessTimeArrival { get; set; }
        public ApproveStatus ApproveStatus { get; set; }
        public string? Note { get; set; }
        public bool IsStart { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public User? Creator { get; set; }
        public User? Updater { get; set; }
    }
}
