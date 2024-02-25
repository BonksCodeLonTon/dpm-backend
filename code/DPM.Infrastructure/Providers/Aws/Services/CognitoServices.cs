using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Infrastructure.Providers.Aws.Services
{
    internal class CognitoService : IAuthenticationService
    {
        public class Options
        {
            public static readonly string SectionName = "Cognito";

            [Required]
            public string UserPoolId { get; set; } = default!;

            [Required]
            public string UserPoolClientId { get; set; } = default!;
        }

        private readonly IAmazonCognitoIdentityProvider _cognitoIdentityProvider;
        private readonly Options _options;

        public CognitoService(IAmazonCognitoIdentityProvider cognitoIdentityProvider, IOptionsSnapshot<Options> options)
        {
            _cognitoIdentityProvider = cognitoIdentityProvider;
            _options = options.Value;
        }

        public async Task<string> CreateUserAsync(string email, string username, string? password)
        {
            AdminCreateUserResponse response;

            try
            {
                response = await _cognitoIdentityProvider.AdminCreateUserAsync(
                  new AdminCreateUserRequest
                  {
                      UserPoolId = _options.UserPoolId,
                      Username = username,
                      UserAttributes =
                     new List<AttributeType> {
              new AttributeType {
                  Name = "email",
                  Value = email
              }
                     },
                      MessageAction = MessageActionType.SUPPRESS,
                  }
               );
            }
            catch (UsernameExistsException)
            {
                throw new ConflictException(nameof(User));
            }
            catch (Exception)
            {
                throw;
            }

            if (password != null)
            {
                await _cognitoIdentityProvider.AdminSetUserPasswordAsync(
                   new AdminSetUserPasswordRequest
                   {
                       UserPoolId = _options.UserPoolId,
                       Username = username,
                       Password = password,
                       Permanent = true
                   }
                 );
            }

            return response.User.Attributes.First(x => x.Name == "sub").Value;
        }
    }

}
