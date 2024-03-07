using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Domain.Enums
{
    public enum ShipType
    {
        [Description("Loại khác")]
        Other,
        [Description("Chở cá")]
        Carrying,
        [Description("Đánh bắt cá")]
        Fishing
    }
}
