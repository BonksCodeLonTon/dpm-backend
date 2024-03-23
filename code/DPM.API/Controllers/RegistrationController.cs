using DPM.Applications.Common;
using DPM.Applications.Features.SailingRegister;
using DPM.Applications.Features.SailingRegister.GetArrivalRegistations;
using DPM.Applications.Features.SailingRegister.GetArrivalRegistrationsWithStatus;
using DPM.Applications.Features.SailingRegister.GetDepartRegistrations;
using DPM.Applications.Features.SailingRegister.GetDepartRegistrationsWithStatus;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DPM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class RegistrationController : BaseController
    {
        public RegistrationController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost("arrival")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ArrivalRegistration(RegisterToArrivalCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }
        [HttpPost("departure")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DepartRegistration(RegisterToDepartureCommand  command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }
        [HttpGet("departure/all")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDepartRegistration([FromQuery] GetDepartRegistrationsQuery query)
        {
            var result = await _mediator.Send(query);
            return CreateSuccessResult(result);
        }
        [HttpGet("arrival/all")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetArrivalRegistration([FromQuery] GetArrivalRegistationsQuery query)
        {
            var result = await _mediator.Send(query);
            return CreateSuccessResult(result);
        }
        [HttpPost("departure/all-with-status")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDepartRegistrationWithStatus([FromQuery] GetDepartRegistrationsWithStatusQuery query)
        {
            var result = await _mediator.Send(query);
            return CreateSuccessResult(result);
        }
        [HttpPost("arrival/all-with-status")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetArrivalRegistrationWithStatus([FromQuery] GetArrivalRegistrationsWithStatusQuery query)
        {
            var result = await _mediator.Send(query);
            return CreateSuccessResult(result);
        }
    }
}
