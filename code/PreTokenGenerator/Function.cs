using Amazon.Lambda.Core;
using Amazon.Lambda.CognitoEvents;
using Amazon.Lambda.Serialization.SystemTextJson;
using Npgsql;
using Dapper;
using DPM.Functions.Shared;
using DPM.Domain.Entities;
using System.Text.RegularExpressions;
using DPM.Domain.Enums;
// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(DefaultLambdaJsonSerializer))]
namespace DPM.PreTokenGeneration;

public class Function
{
    private NpgsqlConnection? _connection = null;

    public async Task<CognitoPreTokenGenerationEvent> Handler(CognitoPreTokenGenerationEvent cognitoEvent)
    {
        var usernameRegex = new Regex(@"^[a-zA-Z0-9_]+$");
        _connection ??= new NpgsqlConnection(await Config.GetConnectionString());
        Console.WriteLine(cognitoEvent.UserName);
        User user;

        if (usernameRegex.IsMatch(cognitoEvent.UserName))
        {
            user = _connection.QuerySingle<User>(
                "SELECT * FROM users WHERE username = @username",
                new { username = cognitoEvent.UserName }
            );
        }
        else
        {
            user = _connection.QuerySingle<User>(
                "SELECT * FROM users WHERE email = @username",
                new { username = cognitoEvent.UserName }
            );
        }

        cognitoEvent.Response.ClaimsOverrideDetails = new ClaimOverrideDetails
        {
            ClaimsToAddOrOverride = new Dictionary<string, string>
        {
          { "user_id", user.Id.ToString() },
          { "role_type", Enum.GetName(typeof(RoleType), user.RoleType) },
          { "role", Enum.GetName(typeof(Role), user.Role) }
        }
        };

        return cognitoEvent;
    }
}
