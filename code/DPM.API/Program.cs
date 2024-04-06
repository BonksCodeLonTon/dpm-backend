using Autofac;
using Autofac.Extensions.DependencyInjection;
using DPM.Infrastructure;
using DPM.Infrastructure.Common;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Production")
{
    builder.WebHost.UseUrls("http://localhost:5000");
}

builder.Host.ConfigureHostConfiguration((config) => config.AddEnvironmentVariables());
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>((ctx, containerBuilder) =>
{
    containerBuilder.RegisterModule(new InfrastructureModule(ctx.Configuration));
    containerBuilder.RegisterInstance<IConfiguration>(builder.Configuration);
});

// Adding services for Controllers
builder.Services
    .AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); })
    .AddApplicationPart(typeof(InfrastructureModule).Assembly);

// Configure CORS
builder.Services.AddCors(options =>
    options.AddPolicy(name: "AllOrigins", policy =>
        policy
            .WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod()));

// Configure Swagger
builder.Services.AddSwaggerGen(c =>
{

    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DPM.API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "DPM.API.xml"));
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(
        c =>
{
    c.PreSerializeFilters.Add((swagger, httpReq) =>
    {
        swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"https://{httpReq.Host.Value}/{httpReq.Headers["X-Forwarded-Prefix"]}" } };
    });
});
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("./swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty;
    });
}
app.UseCors("AllOrigins");

app.UseRequestLocalization(new RequestLocalizationOptions
{
    SupportedCultures = Constants.SupportedCultures,
    SupportedUICultures = Constants.SupportedCultures,
    DefaultRequestCulture = new RequestCulture(Constants.DefaultCulture),
    RequestCultureProviders = new List<IRequestCultureProvider>
    {
        new AcceptLanguageHeaderRequestCultureProvider()
    },
});

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(config =>
    {
        config.MapHealthChecks("/health", new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = async (context, report) =>
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = report.Status == HealthStatus.Healthy ? StatusCodes.Status200OK : StatusCodes.Status503ServiceUnavailable;

                await context.Response.WriteAsync(JsonSerializer.Serialize(new
                {
                    status = report.Status.ToString(),
                    services = report.Entries.Select(e => new
                    {
                        name = e.Key,
                        status = Enum.GetName(typeof(HealthStatus), e.Value.Status),
                    })
                }));
            }
        });

        config.MapControllers();
    });

app.Run();