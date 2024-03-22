using Autofac;
using Microsoft.Extensions.Configuration;
using Serilog.Extensions.Autofac.DependencyInjection;

namespace DPM.Infrastructure.Serilog
{
    internal class SerilogModule : Module
    {
        public class Options
        {
            public static readonly string SectionName = "ElasticSearch";

            public string? Uri { get; set; } = default!;
            public string? User { get; set; } = default!;
            public string? Password { get; set; } = default!;
        }

        public SerilogModule(IConfiguration configuration)
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            var logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.log");
            builder.RegisterSerilog(logPath);
        }
    }
}