using DPM.Applications.Common;
using DPM.Applications.Features.Port.CreatePort;
using DPM.Applications.Features.Port.DeletePort;
using DPM.Applications.Features.Port.GetPort;
using DPM.Applications.Features.Port.GetPorts;
using DPM.Applications.Features.Port.UpdatePort;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DPM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]

    public class PortController : BaseController
    {
        public PortController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet("all")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllPorts([FromQuery] GetPortsQuery query)
        {
            var result = await _mediator.Send(query);
            return CreateSuccessResult(result);
        }

        [HttpGet("get-single")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPort([FromQuery] GetPortQuery query)
        {
            var result = await _mediator.Send(query);
            return CreateSuccessResult(result);
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreatePort(CreatePortCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }

        [HttpDelete("delete")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeletePort(DeletePortCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }

        [HttpPatch("update")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateShip(UpdatePortCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }
    }
}
