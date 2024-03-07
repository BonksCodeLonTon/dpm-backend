using DPM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Domain.Services.Models
{
    public class SearchResult<T>
    {
        public int TotalRecord { get; set; }

        public List<T>? Items { get; set; }
    }
}
