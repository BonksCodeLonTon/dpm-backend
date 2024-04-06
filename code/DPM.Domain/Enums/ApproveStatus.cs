using System;
using System.ComponentModel;

namespace DPM.Domain.Enums
{
    public enum ApproveStatus
    {
        [Description("None")]
        None,
        [Description("Rejected by Military")]
        RejectedByMilitary,
        [Description("Rejected by Port Authority")]
        RejectedByPortAuthority,
        [Description("Approved by Military")]
        ApprovedByMilitary,
        [Description("Approved by Port Authority")]
        ApprovedByPortAuthority,
        [Description("Approving")]
        Approving,


    }
}
