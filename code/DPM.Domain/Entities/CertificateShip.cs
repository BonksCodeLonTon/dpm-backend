using DPM.Domain.Common.Models;
using DPM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Domain.Entities
{
    public class CertificateShip : BaseEntity, ISoftDeletableEntity
    {
        public string? CertificateName { get; set; }
        public Guid CertificateNo { get; set; }
        public CertificateStatus CertificateStatus { get; set; }
        public bool IsMilitaryAuthority { get; set; }
        public bool IsPortAuthority { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public long FishingTripId { get; set; }
        public FishingTrip? FishingTrip { get; set; }
        public bool IsDeleted { get ; set; }
    }
}
