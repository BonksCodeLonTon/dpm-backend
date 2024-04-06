using DPM.Applications.Common;

using DPM.Applications.Features.PortAuthorityUsers.Admin.CreatePortAuthorityUser;
using DPM.Applications.Features.PortAuthorityUsers.Admin.FindPortAuthorityUser;
using DPM.Applications.Features.PortAuthorityUsers.Admin.GetPortAuthorityUsers;
using DPM.Applications.Features.PortAuthorityUsers.Admin.InviteToPortAuthority;
using DPM.Applications.Features.PortAuthorityUsers.Admin.ReadInviteTokenPortAuthority;
using DPM.Applications.Features.PortAuthorityUsers.Admin.RemovePortAuthorityUser;
using DPM.Applications.Features.PortAuthorityUsers.PortAuthorityArriveApprove;
using DPM.Applications.Features.PortAuthorityUsers.PortAuthorityArriveReject;
using DPM.Applications.Features.PortAuthorityUsers.PortAuthorityDepartApprove;
using DPM.Applications.Features.PortAuthorityUsers.PortAuthorityDepartReject;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DPM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class PortAuthorityController : BaseController
    {
        public PortAuthorityController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("admin/invite/send")]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SendInvitation(InviteToPortAuthorityCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }

        [HttpGet("invite/{token}")]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ReadInvite(string token)
        {
            var origin = await _mediator.Send(new ReadInviteTokenPortAuthorityCommand { Token = token });

            return Redirect(origin);
        }
        [HttpPost("admin/create-user")]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreatePortAuthorityUser([FromBody] CreatePortAuthorityUserCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }
        [HttpPost("admin/find-user")]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> FindPortAuthorityUser([FromQuery] FindPortAuthorityUserQuery query)
        {
            var result = await _mediator.Send(query);
            return CreateSuccessResult(result);
        }
        [HttpGet("admin/get-all-users")]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllPortAuthorityUsers([FromQuery] GetPortAuthorityUsersQuery query)
        {
            var result = await _mediator.Send(query);
            return CreateSuccessResult(result);
        }
        [HttpDelete("admin/delete-user")]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RemovePortAuthorityUser(RemovePortAuthorityUserCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }
        [HttpPost("depart/approve")]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ApproveDepartRegistation(PortAuthorityDepartApproveCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }
        [HttpPost("depart/reject")]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RejectDepartRegistation(PortAuthorityDepartRejectCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }
        [HttpPost("arrive/approve")]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ApproveArrivalRegistation(PortAuthorityArriveApproveCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }
        [HttpPost("arrive/reject")]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RejectArrivalRegistation(PortAuthorityArriveRejectCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }

    }
}