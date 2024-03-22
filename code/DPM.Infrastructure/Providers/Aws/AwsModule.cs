using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.SimpleEmail;
using Autofac;
using DPM.Applications.Services;
using DPM.Infrastructure.Providers.Aws.Services;
using Microsoft.Extensions.Configuration;

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

            builder.Register(c => new AmazonCognitoIdentityProviderClient(credentials, RegionEndpoint.APSoutheast1))
                .As<IAmazonCognitoIdentityProvider>()
                .InstancePerLifetimeScope();
            builder.RegisterInstance(new AmazonSimpleEmailServiceClient(credentials, RegionEndpoint.APSoutheast1))
                .As<IAmazonSimpleEmailService>();
            builder.RegisterInstance(new AmazonS3Client(credentials, RegionEndpoint.APSoutheast1))
                .As<IAmazonS3>();
            builder.RegisterType<CognitoService>()
              .As<IAuthenticationService>()
              .SingleInstance();
            builder.RegisterType<SesService>()
              .As<IEmailService>()
              .SingleInstance();
            builder.RegisterType<S3Service>()
              .As<IStorageService>()
              .SingleInstance();
        }
    }
}