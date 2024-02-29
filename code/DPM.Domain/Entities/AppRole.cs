using DPM.Domain.Common.Models;
using DPM.Domain.Enums;

namespace DPM.Domain.Entities
{
    public class AppRole : BaseEntity
    {
        public Role RoleName { get; set; }
    }
}
