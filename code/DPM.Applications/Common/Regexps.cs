using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Common
{
    public class Regexps
    {
        public static readonly string PhoneNumber = @"^([\+]?[0-9]{2,3}[-]?|[0])?[1-9][0-9]{8}$";
        public static readonly string NationalId = @"^[0-9]{3}[0-9]{9}$";

    }
}
