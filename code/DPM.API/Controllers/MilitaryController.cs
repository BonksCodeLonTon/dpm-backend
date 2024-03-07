using AutoMapper;
using DPM.Applications.Common;
using DPM.Applications.Features.MilitaryUsers.Admin.InviteToMilitary;
using DPM.Applications.Features.MilitaryUsers.Admin.ReadInviteTokenMilitary;
using DPM.Domain.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> Index(string token)
        {
            var origin = await _mediator.Send(new ReadInviteTokenMilitaryCommand { Token = token });

            return Redirect(origin);
        }
    }
}
