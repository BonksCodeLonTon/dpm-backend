using Autofac;
using DPM.Applications.Services;
using DPM.Infrastructure.Services;
using Microsoft.AspNetCore.Http;

namespace DPM.Infrastructure.Modules
{
    internal class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HttpContextAccessor>()
              .As<IHttpContextAccessor>()
              .SingleInstance();
            builder.RegisterType<RequestContextService>()
              .As<IRequestContextService>()
              .SingleInstance();
            builder.RegisterType<JwtService>()
              .As<IJwtService>()
              .SingleInstance();
            builder.RegisterType<AsyncRunnerService>()
              .As<IAsyncRunnerService>()
              .SingleInstance();
        }
    }

}
