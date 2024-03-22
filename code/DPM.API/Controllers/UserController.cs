using DPM.Applications.Common;
using DPM.Applications.Features.Users.FindUsers;
using DPM.Applications.Features.Users.GetMe;
using DPM.Applications.Features.Users.GetUsers;
using DPM.Applications.Features.Users.UpdateMe;
using DPM.Applications.Features.Users.UpdateUserStatus;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DPM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("me")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetMe(GetMeQuery query)
        {
            var result = await _mediator.Send(query);
            return CreateSuccessResult(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> FindUser(FindUsersQuery query)
        {
            var result = await _mediator.Send(query);
            return CreateSuccessResult(result);
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllUsers(GetUsersQuery query)
        {
            var result = await _mediator.Send(query);
            return CreateSuccessResult(result);
        }

        [HttpPatch("me")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateMe(UpdateMeCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }

        [HttpPatch("status")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateUserStatus(UpdateUserStatusCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }
    }
}