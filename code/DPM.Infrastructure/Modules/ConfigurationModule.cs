using Autofac;
using Autofac.Extensions.DependencyInjection;
using DPM.Infrastructure.Database;
using DPM.Infrastructure.Providers.Aws.Services;
using DPM.Infrastructure.Providers.DevExpress;
using DPM.Infrastructure.Serilog;
using DPM.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DPM.Infrastructure.Modules
{
    internal class ConfigurationModule : Module
    {
        private readonly IConfiguration _configuration;

        public ConfigurationModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var services = new ServiceCollection();

            services.AddOptions<CognitoService.Options>()
              .Bind(_configuration.GetRequiredSection(CognitoService.Options.SectionName))
              .ValidateDataAnnotations()
              .ValidateOnStart();
            services.AddOptions<SesService.Options>()
              .Bind(_configuration.GetRequiredSection(SesService.Options.SectionName))
              .ValidateDataAnnotations()
              .ValidateOnStart();
            services.AddOptions<S3Service.Options>()
              .Bind(_configuration.GetRequiredSection(S3Service.Options.SectionName))
              .ValidateDataAnnotations()
              .ValidateOnStart();
            services.AddOptions<DigitalSigningService.Options>()
              .Bind(_configuration.GetRequiredSection(DigitalSigningService.Options.SectionName))
              .ValidateDataAnnotations()
              .ValidateOnStart();
            services.AddOptions<CacheModule.Options>()
              .Bind(_configuration.GetSection(CacheModule.Options.SectionName))
              .ValidateDataAnnotations()
              .ValidateOnStart();
            services.AddOptions<DatabaseModule.Options>()
              .Bind(_configuration.GetRequiredSection(DatabaseModule.Options.SectionName))
              .ValidateDataAnnotations()
              .ValidateOnStart();
            services.AddOptions<DatabaseModule.Options>()
              .Bind(_configuration.GetRequiredSection(SerilogModule.Options.SectionName))
              .ValidateDataAnnotations()
              .ValidateOnStart();
            services.AddOptions<JwtService.Options>()
              .Bind(_configuration.GetRequiredSection(JwtService.Options.SectionName))
              .ValidateDataAnnotations()
              .ValidateOnStart();
            builder.Populate(services);
        }
    }
}