using DPM.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DPM.Domain.Entities
{
    public class CertificateShipHistory : BaseEntity
    {
        public long CertificateShipId { get; set; }
        public JsonElement Before { get; set; }
        public JsonElement After { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public User? Creator { get; set; }
        public User? Updater { get; set; }
        public CertificateShip? CertificateShip { get; set; }

    }
}
