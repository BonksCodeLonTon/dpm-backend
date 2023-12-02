using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Text.Json.Serialization;

namespace DPM.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);

            services.AddLocalization();

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
