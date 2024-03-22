using DPM.Applications.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DPM.API.Controllers
{
    [Produces("application/json", new string[] { })]
    [Authorize]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected IActionResult CreateSuccessResult<T>(T result)
        {
            return Ok(new HandlerResult<T>(result));
        }

        protected IActionResult CreateSuccess()
        {
            return Ok(new HandlerResult());
        }

        private IEnumerable<ErrorCodeDetail> ConvertError(IEnumerable<string> details)
        {
            return details.Select((string p) => new ErrorCodeDetail
            {
                Message = p
            }).ToList();
        }

        protected IActionResult CreateFailResult(string error, string errorCode, IEnumerable<string> details)
        {
            return BadRequest(new FailHandlerResult(error, errorCode, ConvertError(details)));
        }

        protected IActionResult CreateFailResult(string error, string errorCode, IEnumerable<ErrorCodeDetail> details)
        {
            return BadRequest(new FailHandlerResult(error, errorCode, details));
        }

        protected IActionResult CreateFailResult(string error, IEnumerable<string> details)
        {
            return BadRequest(new FailHandlerResult(error, "", ConvertError(details)));
        }

        protected IActionResult CreateFailResult(string error, IEnumerable<ErrorCodeDetail> details)
        {
            return BadRequest(new FailHandlerResult(error, "", details));
        }

        protected IActionResult CreateFailResult(string error)
        {
            return BadRequest(new FailHandlerResult(error, "", null));
        }
    }
}