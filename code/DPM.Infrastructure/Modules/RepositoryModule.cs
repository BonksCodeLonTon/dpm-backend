using Autofac;
using DPM.Domain.Repositories;
using DPM.Infrastructure.Database.Repositories;

namespace DPM.Infrastructure.Modules
{
    internal class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>()
              .As<IUserRepository>()
              .InstancePerLifetimeScope();
            builder.RegisterType<ShipRepository>()
              .As<IShipRepository>()
              .InstancePerLifetimeScope();
            builder.RegisterType<ShipRepository>()
              .As<IShipRepository>()
              .InstancePerLifetimeScope();
            builder.RegisterType<ShipRepository>()
              .As<IShipRepository>()
              .InstancePerLifetimeScope();
            builder.RegisterType<ShipRepository>()
              .As<IShipRepository>()
              .InstancePerLifetimeScope();
            builder.RegisterType<ShipRepository>()
              .As<IShipRepository>()
              .InstancePerLifetimeScope();
            builder.RegisterType<ShipRepository>()
              .As<IShipRepository>()
              .InstancePerLifetimeScope();
        }
    }
}