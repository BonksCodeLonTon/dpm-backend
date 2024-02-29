using DPM.Applications.Features.Auth.SendForgotPasswordCode;
using DPM.Applications.Features.Auth.SignIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Services
{
    public interface IAuthenticationService
    {
        Task<string> SignUpAsync(string email, string username, string? password, string phone, string fullName);
        Task<bool> ConfirmSignUpAsync(string username, string confirmationCode);
        Task<bool> ResendConfirmationCodeAsync(string userName);
        Task<SignInResponse> SignInAsync(string username, string password);
        Task<SendForgotPasswordResponse> SendForgotPasswordCodeAsync(string username);
        Task<bool> ChangePasswordAsync(string previousPassword, string proposedPassword, string? accessToken);
        Task<bool> ConfirmForgotPasswordAsync(string username, string password, string confirmationCode);
        Task<bool> SignOutAsync(string? accessToken);
        Task<string> CreateUserAsync(string email, string username, string? password);
    }
}
