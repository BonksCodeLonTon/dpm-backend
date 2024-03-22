using DPM.Applications.Common;
using DPM.Applications.Features.SailingRegister.RegisterToArrivalCommand;
using DPM.Applications.Features.SailingRegister.RegisterToDepartureCommand;
using DPM.Domain.Entities;
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
    }
}
