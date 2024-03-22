using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using DPM.Applications.Features.Auth.SendForgotPasswordCode;
using DPM.Applications.Features.Auth.SignIn;
using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

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

        public async Task<string> SignUpAsync(string email, string username, string? password, string phone, string fullName)
        {
            try
            {
                SignUpRequest cognitoRequest = new SignUpRequest
                {
                    ClientId = _options.UserPoolClientId,
                    Username = username,
                    Password = password,
                };
                cognitoRequest.UserAttributes.Add(new AttributeType { Name = "email", Value = email });
                cognitoRequest.UserAttributes.Add(new AttributeType { Name = "phone_number", Value = phone });
                cognitoRequest.UserAttributes.Add(new AttributeType { Name = "name", Value = fullName });

                SignUpResponse cognitoResponse = await _cognitoIdentityProvider.SignUpAsync(cognitoRequest);
                return cognitoResponse.UserSub;
            }
            catch (UsernameExistsException)
            {
                throw new ConflictException(nameof(User));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ConfirmSignUpAsync(string username, string confirmationCode)
        {
            try
            {
                ConfirmSignUpRequest cognitoRequest = new ConfirmSignUpRequest
                {
                    ClientId = _options.UserPoolClientId,
                    Username = username,
                    ConfirmationCode = confirmationCode
                };
                await _cognitoIdentityProvider.ConfirmSignUpAsync(cognitoRequest);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SignInResponse> SignInAsync(string username, string password)
        {
            try
            {
                InitiateAuthRequest cognitoRequest = new InitiateAuthRequest
                {
                    AuthFlow = AuthFlowType.USER_PASSWORD_AUTH,
                    ClientId = _options.UserPoolClientId
                };
                cognitoRequest.AuthParameters.Add("USERNAME", username);
                cognitoRequest.AuthParameters.Add("PASSWORD", password);
                InitiateAuthResponse cognitoResponse = await _cognitoIdentityProvider.InitiateAuthAsync(cognitoRequest);
                AuthenticationResultType cognitoAuthResult = cognitoResponse.AuthenticationResult;
                return new SignInResponse
                {
                    IdToken = cognitoAuthResult.IdToken,
                    AccessToken = cognitoAuthResult.AccessToken,
                    ExpiresIn = cognitoAuthResult.ExpiresIn,
                    RefreshToken = cognitoAuthResult.RefreshToken
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ConfirmForgotPasswordAsync(string username, string password, string confirmationCode)
        {
            try
            {
                ConfirmForgotPasswordRequest cognitoRequest = new ConfirmForgotPasswordRequest
                {
                    ClientId = _options.UserPoolClientId,
                    ConfirmationCode = confirmationCode,
                    Username = username,
                    Password = password
                };
                await _cognitoIdentityProvider.ConfirmForgotPasswordAsync(cognitoRequest);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ResendConfirmationCodeAsync(string userName)
        {
            try
            {
                var codeRequest = new ResendConfirmationCodeRequest
                {
                    ClientId = _options.UserPoolClientId,
                    Username = userName,
                };

                var response = await _cognitoIdentityProvider.ResendConfirmationCodeAsync(codeRequest);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SignOutAsync(string? accessToken)
        {
            try
            {
                GlobalSignOutRequest cognitoRequest = new GlobalSignOutRequest
                {
                    AccessToken = accessToken
                };

                await _cognitoIdentityProvider.GlobalSignOutAsync(cognitoRequest);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SendForgotPasswordResponse> SendForgotPasswordCodeAsync(string username)
        {
            try
            {
                ForgotPasswordRequest cognitoRequest = new ForgotPasswordRequest
                {
                    Username = username,
                    ClientId = _options.UserPoolClientId
                };
                ForgotPasswordResponse cognitoResponse = await _cognitoIdentityProvider.ForgotPasswordAsync(cognitoRequest);

                return new SendForgotPasswordResponse
                {
                    CodeDeliveryMessage = $"A Reset Password Code has been sent to {cognitoResponse.CodeDeliveryDetails.Destination} via {cognitoResponse.CodeDeliveryDetails.DeliveryMedium.Value}"
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ChangePasswordAsync(string previousPassword, string proposedPassword, string? accessToken)
        {
            try
            {
                ChangePasswordRequest cognitoRequest = new ChangePasswordRequest
                {
                    PreviousPassword = previousPassword,
                    ProposedPassword = proposedPassword,
                    AccessToken = accessToken
                };
                await _cognitoIdentityProvider.ChangePasswordAsync(cognitoRequest);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
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