using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DPM.Domain.Common.Models;
using DPM.Domain.Entities;
using DPM.Infrastructure.Auth.Policies;
using DPM.Infrastructure.Common;
using DPM.Infrastructure.Database;
using DPM.Infrastructure.Providers.Aws.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
namespace DPM.Infrastructure.Auth
{
    internal class AuthModule : Module
    {
        private readonly IConfiguration _configuration;

        public AuthModule(IConfiguration configuration)
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
            var options = _configuration.GetSection(CognitoService.Options.SectionName).Get<CognitoService.Options>();
            var cognitoIssuer = $"https://cognito-idp.{Constants.AwsRegion}.amazonaws.com/{options.UserPoolId}";
            var cognitoAudience = options.UserPoolClientId;

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.ConfigurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
           $"{cognitoIssuer}/.well-known/openid-configuration",
           new OpenIdConnectConfigurationRetriever(),
           new HttpDocumentRetriever { RequireHttps = true });
                    options.TokenValidationParameters =
           new TokenValidationParameters
                    {
                        ValidIssuer = cognitoIssuer,
                        ValidAudience = cognitoAudience,
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateAudience = true,
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsAdmin", policy => policy.Requirements.Add(new IsAdminRequirement()));
                options.AddPolicy("IsMilitary", policy => policy.Requirements.Add(new IsRoleRequirement(Domain.Enums.Role.Military)));
                options.AddPolicy("IsPortAuthority", policy => policy.Requirements.Add(new IsRoleRequirement(Domain.Enums.Role.PortAuthority)));

            });

            services.AddSingleton<IAuthorizationHandler, IsRoleHandler>();
            builder.Populate(services);
        }
    }
}
