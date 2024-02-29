using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string[] recipients, string templateName, object templateDataObject);
    }
}
