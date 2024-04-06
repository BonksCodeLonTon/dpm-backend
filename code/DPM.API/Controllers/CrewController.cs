using DPM.Applications.Common;
using DPM.Applications.Features.Crews.CreateCrew;
using DPM.Applications.Features.Crews.GetCrews;
using DPM.Applications.Features.Crews.UpdateCrew;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DPM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class CrewController : BaseController
    {
        public CrewController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet("all")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllCrews([FromQuery] GetCrewsQuery query)
        {
            var result = await _mediator.Send(query);
            return CreateSuccessResult(result);
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreatePort(CreateCrewCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }

        [HttpPatch("update")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateShip(UpdateCrewCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }
    }
}
