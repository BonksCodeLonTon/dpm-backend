﻿using DPM.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Domain.Entities
{
    public class CertificateShip : BaseEntity
    {
        public string CertificateName { get; set; }
        public string CertificateNo { get; set; }
        public bool IsMilitaryAuthority { get; set; }
        public bool IsPortAuthority { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string ShipId { get; set; }

    }
}
