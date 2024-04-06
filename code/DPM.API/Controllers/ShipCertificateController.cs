using DPM.Applications.Common;
using DPM.Applications.Features.ShipCertificates.GetCertificatesByShipId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DPM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class ShipCertificateController : BaseController
    {
        public ShipCertificateController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet("ship/all")]
        [ProducesResponseType(typeof(HandlerResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailHandlerResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetShipCertificateByShipId([FromQuery] GetCertificatesByShipIdQuery query)
        {
            var result = await _mediator.Send(query);
            return CreateSuccessResult(result);
        }
    }
}
