using AutoMapper;
using DPM.Domain.Common.Interfaces;
using DPM.Domain.Entities;
using DPM.Domain.Features.Auth.Register;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace DPM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : BaseController
    {

        public AccountController(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper, IMediator mediator) : base(unitOfWorkFactory, mapper, mediator)
        {
        }
        [HttpPost]
        [Route("register")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            long userId;
            userId = await _mediator.Send(command);
            return Created(string.Empty, userId);
        }
    }

}

