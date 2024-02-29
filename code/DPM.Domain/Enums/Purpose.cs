using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Domain.Enums
{
    public enum Purpose
    {
        [Description("Chưa đăng kí")]
        None,
        [Description("Chở cá")]
        Carry,
        [Description("Đánh bắt cá")]
        Fish
    }
}
