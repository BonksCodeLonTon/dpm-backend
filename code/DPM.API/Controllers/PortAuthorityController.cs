using DPM.Applications.Common;
using DPM.Applications.Features.PortAuthorityUsers.Admin.InviteToPortAuthority;
using DPM.Applications.Features.PortAuthorityUsers.Admin.ReadInviteTokenPortAuthority;
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
        public async Task<IActionResult> Index(string token)
        {
            var origin = await _mediator.Send(new ReadInviteTokenPortAuthorityCommand { Token = token });

            return Redirect(origin);
        }
    }
}