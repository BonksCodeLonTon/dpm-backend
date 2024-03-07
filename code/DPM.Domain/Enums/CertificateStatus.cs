using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Domain.Enums
{
    public enum CertificateStatus
    {
        [Description("Đã duyệt")]
        Accepted,
        [Description("Từ chối")]
        Rejected,
        [Description("Hết hạn")]
        Expired,
        [Description("Đang duyệt")]
        Approving,
        None,
    }
}
