using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Domain.Models.ResponseModel.Account
{
    public class AccountPermissionResponse
    {
        public List<string> Roles { get; set; }
        public List<string> Permissions { get; set; }
    }
}
