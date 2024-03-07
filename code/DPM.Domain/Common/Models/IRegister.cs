using DPM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Domain.Common.Models
{
    public interface IRegister
    {
        public long RegisterById { get; set; }
        public long ShipId { get; set; }
        public long PortId { get; set; }
        public ApproveStatus ApproveStatus { get; set; }
        public long CaptainId { get; set; }
        public bool IsStart { get; set; }

    }
}
