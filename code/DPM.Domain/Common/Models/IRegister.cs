using DPM.Domain.Enums;

namespace DPM.Domain.Common.Models
{
    public interface IRegister
    {
        public long ShipId { get; set; }
        public long PortId { get; set; }
        public string? Note { get; set; }

        public ApproveStatus ApproveStatus { get; set; }
        public long CaptainId { get; set; }
        public bool IsStart { get; set; }
    }
}