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
        [Description("Từ chối xuất cảng")]
        Rejected,
        [Description("Đang hoãn duyệt")]
        Pending,
        [Description("Đang duyệt")]
        Approving,
        None,
    }
}
