using Autofac;
using DPM.Applications;
using DPM.Infrastructure.Auth;
using DPM.Infrastructure.Common;
using DPM.Infrastructure.Database;
using DPM.Infrastructure.Modules;
using DPM.Infrastructure.Providers.Aws;
using DPM.Infrastructure.Serilog;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Infrastructure
{
    public class InfrastructureModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public InfrastructureModule(IConfiguration configuration)
        {
            var _ = new[] { typeof(Hook) };
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var applicationAssembly = AppDomain.CurrentDomain.GetAssemblies()
              .Where(x => x.GetName().Name == "DPM.Applications")
              .FirstOrDefault(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new ConfigurationModule(_configuration));
            builder.RegisterModule(new AuthModule(_configuration));
            builder.RegisterModule(new AutoMapperModule(applicationAssembly));
            builder.RegisterModule(new AwsModule(_configuration));
            builder.RegisterModule(new CacheModule(_configuration));
            builder.RegisterModule(new DatabaseModule(_configuration));
            builder.RegisterModule(new FluentValidationModule(applicationAssembly));
            builder.RegisterModule(new SerilogModule(_configuration));
            builder.RegisterModule(new MediatRModule(applicationAssembly));
            builder.RegisterModule(new ServiceModule());

        }
    }

}
