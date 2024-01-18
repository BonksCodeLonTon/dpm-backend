using Autofac;
using DPM.API.Ultilities;
using DPM.Infrastructure.Modules;
using System.Text.Json.Serialization;

namespace DPM.API
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration , IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new InfrastructureModule(Configuration));
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);

            services.AddLocalization();

            services.ConfigureSwagger();

            services.ConfigureLogging(Configuration, _env);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins",
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:5000")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                                  });
            });

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Register StaticServiceProvider

            if (!env.IsProduction())
            {
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("./swagger/v1/swagger.json", "API v1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseCors("AllowSpecificOrigins");

            app.UseRequestLocalization(new RequestLocalizationOptions()
                .SetDefaultCulture("en-US")
            );

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
