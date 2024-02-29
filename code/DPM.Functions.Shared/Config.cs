using System;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace DPM.Functions.Shared
{
    public class Config
    {
        public static async Task<string> GetConnectionString()
        {
            var client = new AmazonSecretsManagerClient();
            var request = new GetSecretValueRequest
            {
                SecretId = "DB_SECRET_NAME",
                VersionStage = "AWSCURRENT"
            };
            var response = await client.GetSecretValueAsync(request);
            var secretString = response.SecretString
              ?? throw new Exception("Failed to get secret string");
            var config = JsonSerializer.Deserialize<SecretConfig>(secretString,
              new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })
              ?? throw new Exception("Failed to deserialize secret config");

            return
              $@"
        Server={config.Host};
        Port={config.Port};
        Userid={config.Username};
        Password={config.Password};
        Database={config.DbName}".Replace("\n", "");
        }
    }

    public class SecretConfig
    {
        public string Password { get; set; } = default!;
        public string DbName { get; set; } = default!;
        public string Engine { get; set; } = default!;
        public int Port { get; set; } = default!;
        public string DbInstanceIdentifier { get; set; } = default!;
        public string Host { get; set; } = default!;
        public string Username { get; set; } = default!;
    }
}