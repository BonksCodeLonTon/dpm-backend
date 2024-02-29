using DPM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Common
{
    public class HandlerResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public string ErrorCode { get; set; }

        public IEnumerable<ErrorCodeDetail> ErrorDetails { get; set; }

        public HandlerResult(bool success, string message, string errorCode, IEnumerable<ErrorCodeDetail> errorDetails)
        {
            Success = success;
            Message = message;
            ErrorCode = errorCode;
            ErrorDetails = errorDetails;
        }

        public HandlerResult()
        {
            Success = true;
        }
    }
    public class HandlerResult<T> : HandlerResult
    {
        public T Result { get; set; }

        public HandlerResult()
            : base(success: true, string.Empty, null, null)
        {
        }

        public HandlerResult(T result)
            : this()
        {
            Result = result;
        }
    }

}
