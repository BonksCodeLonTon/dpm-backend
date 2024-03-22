using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Domain.Common.Models
{
    public class PdfSignature
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Reason { get; set; }
        public byte[] ImageData { get; set; }
    }
}
