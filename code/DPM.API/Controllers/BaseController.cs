using AutoMapper;
using DPM.Domain.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DPM.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IUnitOfWorkFactory _unitOfWorkFactory;
        protected readonly IMapper _mapper;
        protected readonly IMediator _mediator;
        public BaseController(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper, IMediator mediator)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _mapper = mapper;
            _mediator = mediator;
        }
    }
}
