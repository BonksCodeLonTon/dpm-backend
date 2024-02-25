using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.Runtime;
using Autofac;
using DPM.Applications.Services;
using DPM.Infrastructure.Providers.Aws.Services;
using Microsoft.Extensions.Configuration;
using System;

namespace DPM.Infrastructure.Providers.Aws
{
    internal class AwsModule : Module
    {
        private readonly IConfiguration _configuration;
        public class Options
        {
            public static readonly string SectionName = "AWS";
            public string? AccessKeyId { get; set; }
            public string? SecretAccessKey { get; set; }
        }
        public AwsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

    protected override void Load(ContainerBuilder builder)
        {
            var options = _configuration.GetSection(Options.SectionName).Get<Options>() ?? new Options();

            AWSCredentials credentials = new BasicAWSCredentials(options.AccessKeyId, options.SecretAccessKey);

            builder.Register(c => new AmazonCognitoIdentityProviderClient(credentials, RegionEndpoint.APSoutheast1 ))
                   .As<IAmazonCognitoIdentityProvider>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<CognitoService>()
                   .As<IAuthenticationService>()
                   .SingleInstance();
        }
    }
}
