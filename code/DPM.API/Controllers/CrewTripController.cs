using DPM.Applications.Common;
using DPM.Applications.Features.CrewTrips;
using DPM.Applications.Features.CrewTrips.GetStartCrewTrips;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DPM.API.Controllers
{
    public class CrewTripController : BaseController
    {
        public CrewTripController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet("all")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCrewTrips()
        {
            var getAllCrewTripsQuery = new GetCrewTripsQuery();
            var result = await _mediator.Send(getAllCrewTripsQuery);
            return CreateSuccessResult(result);
        }

        [HttpGet("is-start/all")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetIsStartCrewTrips()
        {
            var getStartCrewTripsQuery = new GetStartCrewTripsQuery();
            var result = await _mediator.Send(getStartCrewTripsQuery);
            return CreateSuccessResult(result);
        }

    }
}
