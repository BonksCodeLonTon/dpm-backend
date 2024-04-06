using DPM.Applications.Common;
using DPM.Applications.Features.MilitaryUsers.Admin.CreateMilitaryUser;
using DPM.Applications.Features.MilitaryUsers.Admin.FindMilitaryUser;
using DPM.Applications.Features.MilitaryUsers.Admin.GetMilitaryUsers;
using DPM.Applications.Features.MilitaryUsers.Admin.InviteToMilitary;
using DPM.Applications.Features.MilitaryUsers.Admin.ReadInviteTokenMilitary;
using DPM.Applications.Features.MilitaryUsers.Admin.RemoveMilitaryUser;
using DPM.Applications.Features.MilitaryUsers.MilitaryArriveApprove;
using DPM.Applications.Features.MilitaryUsers.MilitaryArriveReject;
using DPM.Applications.Features.MilitaryUsers.MilitaryDepartApprove;
using DPM.Applications.Features.MilitaryUsers.MilitaryDepartReject;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DPM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class MilitaryController : BaseController
    {
        public MilitaryController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("admin/invite/send")]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SendInvitation(InviteToMilitaryCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }
        [HttpGet("invite/{token}")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ReadInvite(string token)
        {
            var origin = await _mediator.Send(new ReadInviteTokenMilitaryCommand { Token = token });

            return Redirect(origin);
        }
        [HttpPost("admin/create-user")]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateMilitaryUser([FromBody] CreateMilitaryUserCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }
        [HttpPost("admin/find-user")]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> FindMilitaryUser([FromQuery] FindMilitaryUserQuery query)
        {
            var result = await _mediator.Send(query);
            return CreateSuccessResult(result);
        }
        [HttpGet("admin/get-all-users")]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllMilitaryUsers([FromQuery] GetMilitaryUsersQuery query)
        {
            var result = await _mediator.Send(query);
            return CreateSuccessResult(result);
        }
        [HttpDelete("admin/delete-user")]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RemoveMilitaryUser(RemoveMilitaryUserCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }

        [HttpPost("depart/approve")]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ApproveDepartRegistation(MilitaryDepartApproveCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }
        [HttpPost("depart/reject")]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RejectDepartRegistation(MilitaryDepartRejectCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }
        [HttpPost("arrive/approve")]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ApproveArrivalRegistation(MilitaryArriveApproveCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }
        [HttpPost("arrive/reject")]
        [ProducesResponseType(typeof(HandlerResult<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RejectArrivalRegistation(MilitaryArriveRejectCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }
    }
}