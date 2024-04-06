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
            builder.RegisterType<CrewRepository>()
              .As<ICrewRepository>()
              .InstancePerLifetimeScope();
            builder.RegisterType<PortRepository>()
              .As<IPortRepository>()
              .InstancePerLifetimeScope();
            builder.RegisterType<RegisterArrivalRepository>()
              .As<IRegisterArrivalRepository>()
              .InstancePerLifetimeScope();
            builder.RegisterType<RegisterDepartureRepository>()
              .As<IRegisterDepartureRepository>()
              .InstancePerLifetimeScope();
            builder.RegisterType<ShipCertificateRepository>()
              .As<IShipCertificateRepository>()
              .InstancePerLifetimeScope();
            builder.RegisterType<CrewTripRepository>()
              .As<ICrewTripRepository>()
              .InstancePerLifetimeScope();
        }
    }
}