using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using DPM.Applications.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DPM.Infrastructure.Providers.Aws.Services
{
    internal class SesService : IEmailService
    {
        public class Options
        {
            public static readonly string SectionName = "Email";

            [Required]
            public string Sender { get; set; } = default!;
        }

        private readonly IAmazonSimpleEmailService _amazonSimpleEmailService;
        private readonly Options _options;

        public SesService(
          IAmazonSimpleEmailService amazonSimpleEmailService,
          IOptionsSnapshot<Options> options)
        {
            _amazonSimpleEmailService = amazonSimpleEmailService;
            _options = options.Value;
        }

        public async Task SendEmailAsync(string[] recipients, string templateName, object templateDataObject)
        {
            var templateData = JsonSerializer.Serialize(templateDataObject);

            await _amazonSimpleEmailService.SendTemplatedEmailAsync(
              new SendTemplatedEmailRequest
              {
                  Source = _options.Sender,
                  Destination = new Destination
                  {
                      ToAddresses = new List<string>(recipients)
                  },
                  Template = templateName,
                  TemplateData = templateData
              });
        }
    }

}
