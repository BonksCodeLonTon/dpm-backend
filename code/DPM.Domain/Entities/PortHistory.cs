using DPM.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Domain.Entities
{
    internal class PortHistory : BaseEntity
    {
        public long ShipId { get; set; }
        public Ship? Ship { get; set; }
        public string? ArrivalFromPort { get; set; }
        public string? ArrivalToPort { get;set; }
        public string? ArrivalDateTime { get; set; }
        public string? DepartureIntendTime { get; set; }
        public string? DepartureDateTime { get; set; }
    }
}
