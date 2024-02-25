using AutoMapper;
using DPM.Applications.Services;
using DPM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Users.GetMe
{
    public class GetMeQueryHandler : IRequestHandler<GetMeQuery, GetMeResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRequestContextService _requestContextService;
        private readonly IMapper _mapper;

        public GetMeQueryHandler(
          IRequestContextService requestContextService,
          IUserRepository userRepository,
          IMapper mapper)
        {
            _requestContextService = requestContextService;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<GetMeResponse> Handle(GetMeQuery request, CancellationToken cancellationToken)
        {
            var user = _requestContextService.User;

            return Task.FromResult(_mapper.Map<GetMeResponse>(user));
        }
    }

}
