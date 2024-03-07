using Amazon.Lambda.Core;
using Amazon.Lambda.CognitoEvents;
using Amazon.Lambda.Serialization.SystemTextJson;
using Npgsql;
using Dapper;
using DPM.Functions.Shared;
using DPM.Domain.Entities;
// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(DefaultLambdaJsonSerializer))]

namespace DPM.PreTokenGeneration;

public class Function
{
    private NpgsqlConnection? _connection = null;

    public async Task<CognitoPreTokenGenerationEvent> Handler(CognitoPreTokenGenerationEvent cognitoEvent)
    {
        _connection ??= new NpgsqlConnection(await Config.GetConnectionString());
        var user = _connection.QuerySingle<User>(
        "SELECT * FROM users WHERE username = @username",
          new { username = cognitoEvent.UserName }
        );
        cognitoEvent.Response.ClaimsOverrideDetails = new ClaimOverrideDetails
        {
            ClaimsToAddOrOverride = new Dictionary<string, string>
        {
          { "user_id", user.Id.ToString() },
          { "role_type", Enum.GetName(user.RoleType)! },
            {"role", Enum.GetName(user.Role)! }
        }
        };

        return cognitoEvent;
    }
}
