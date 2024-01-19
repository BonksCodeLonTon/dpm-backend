using Autofac;
using DPM.Applications;
using DPM.Infrastructure.Database;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Infrastructure.Modules
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
              .Where(x => x.GetName().Name == "DPM.BackEnd.Application")
              .FirstOrDefault(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new CacheModule(_configuration));
            builder.RegisterModule(new DatabaseModule(_configuration));

        }
    }

}
