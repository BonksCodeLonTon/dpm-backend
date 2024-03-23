using DPM.Applications.Common;
using DPM.Applications.Features.Auth.ChangePassword;
using DPM.Applications.Features.Auth.ConfirmForgotPassword;
using DPM.Applications.Features.Auth.ConfirmSignUp;
using DPM.Applications.Features.Auth.ResendConfirmationCode;
using DPM.Applications.Features.Auth.SendForgotPasswordCode;
using DPM.Applications.Features.Auth.SignIn;
using DPM.Applications.Features.Auth.SignOut;
using DPM.Applications.Features.Auth.SignUp;
using DPM.Domain.Features.Auth.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DPM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class AuthController : BaseController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("admin/register")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SignUp(SignUpCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }

        [HttpPost("register/confirm")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ConfirmSignUp(ConfirmSignUpCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }

        [HttpPost("register/confirm/resend")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ResendConfirmSignUp(ResendConfirmationCodeCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }

        [HttpDelete("signout")]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SignOut(SignOutCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }

        [HttpPost("signin")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(HandlerResult<SignInResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SignIn(SignInCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }

        [HttpGet("password/forgot/getcode")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(HandlerResult<SendForgotPasswordResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SendForgotPasswordCode(SendForgotPasswordCodeCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }

        [HttpPost("password/forgot")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ConfirmForgotPassword(ConfirmForgotPasswordCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }

        [HttpPost("password/change")]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }
    }
}