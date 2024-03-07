using DPM.Domain.Common.Models;
using DPM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Domain.Entities
{
    public class ShipCertificate : BaseEntity, IAuditableEntity
    {
        public string? CertificateName { get; set; }
        public string? CertificateNo { get; set; }
        public CertificateStatus CertificateStatus { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public long? ShipId { get; set; }
        public virtual Ship Ship { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public User? Creator { get; set; }
        public User? Updater { get; set; }
    }
}
