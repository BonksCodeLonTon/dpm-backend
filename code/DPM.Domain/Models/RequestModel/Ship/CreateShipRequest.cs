using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Domain.Models.RequestModel.Ship
{
    public class CreateShipRequest
    {
        public string ShipOwner { get; set; }
        public string ShipName { get; set; }
        public string ShipNumber { get; set; }
        public string ClassNumber { get; set; }
        public string IMONumber { get; set; }
        public string RegisterNumber { get; set; }
        public string Purpose { get; set; }
        public string Tonnage { get; set; }
        public int Power { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime DeadlineRegistration { get; set; }

    }
}
