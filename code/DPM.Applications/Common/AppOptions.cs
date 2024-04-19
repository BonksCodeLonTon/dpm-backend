using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Common
{
    public class AppOptions
    {
        public const string SectionName = "App";

        [Required]
        public string DomainName { get; set; } = default!;

        public int Property
        {
            get => default;
            set
            {
            }
        }
    }

}
