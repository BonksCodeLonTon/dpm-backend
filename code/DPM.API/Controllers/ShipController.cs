using DPM.Applications.Common;
using DPM.Applications.Features.Ships.CreateShip;
using DPM.Applications.Features.Ships.DeleteShip;
using DPM.Applications.Features.Ships.GetMyShip;
using DPM.Applications.Features.Ships.GetShip;
using DPM.Applications.Features.Ships.GetShips;
using DPM.Applications.Features.Ships.UpdateShip;
using DPM.Applications.Features.Ships.UpdateShipLocationById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DPM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class ShipController : BaseController
    {
        public ShipController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllShips()
        {
            var getShipsQuery = new GetShipsQuery();
            var result = await _mediator.Send(getShipsQuery);
            return CreateSuccessResult(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetShip(int id)
        {
            var getShipQuery = new GetShipQuery { Id = id };
            var result = await _mediator.Send(getShipQuery);
            return CreateSuccessResult(result);
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateShip(CreateShipCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }

        [HttpGet("me")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetMyShip()
        {
            var getShipQuery = new GetMyShipQuery();
            var result = await _mediator.Send(getShipQuery);
            return CreateSuccessResult(result);
        }

        [HttpDelete("id")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteShip(long id)
        {
            var getShipQuery = new DeleteShipCommand { Id = id };
            var result = await _mediator.Send(getShipQuery);
            return CreateSuccessResult(result);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateShip(UpdateShipCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }

        [HttpPatch("position/{id}")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateShipPosition(UpdateShipLocationByIdCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateSuccessResult(result);
        }
    }
}