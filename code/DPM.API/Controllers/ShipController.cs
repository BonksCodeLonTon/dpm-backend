using AutoMapper;
using DPM.Applications.Features.Ships.CreateShip;
using DPM.Applications.Features.Ships.GetShip;
using DPM.Applications.Features.Ships.GetShips;
using DPM.Domain.Common.Interfaces;
using DPM.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DPM.API.Controllers
{
    public class ShipController : BaseController
    {
        public ShipController(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper, IMediator mediator) : base (unitOfWorkFactory, mapper, mediator)
        {

        }
        [HttpGet]
        [Route("ships")]
        public async Task<IActionResult> GetShips()
        {
            using var unitOfWork = _unitOfWorkFactory.Create(deferred: true);

            var getShipsQuery = new GetShipsQuery();
            var result = await _mediator.Send(getShipsQuery);
            return Ok(result);
        }
        [HttpGet]
        [Route("ship/{id}")]
        public async Task<IActionResult> GetShip(int id)
        {
            var getShipQuery = new GetShipQuery { Id = id };
            var result = await _mediator.Send(getShipQuery);
            return Ok(result);
        }
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(Ship), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateShip(CreateShipCommand command)
        {
            var ship = await _mediator.Send(command);
            return Created(string.Empty, ship.IMONumber);
        }
    }
}
