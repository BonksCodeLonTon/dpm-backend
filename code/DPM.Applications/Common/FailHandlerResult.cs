using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Common
{
    public class FailHandlerResult : HandlerResult
    {
        public FailHandlerResult(string message)
            : base(success: false, message, null, null)
        {
        }

        public FailHandlerResult(string message, string errorCode, IEnumerable<ErrorCodeDetail> errors)
            : base(success: false, message, errorCode, errors)
        {
        }

        public FailHandlerResult(string message, IEnumerable<ErrorCodeDetail> errors)
            : base(success: false, message, "", errors)
        {
        }
    }
}
