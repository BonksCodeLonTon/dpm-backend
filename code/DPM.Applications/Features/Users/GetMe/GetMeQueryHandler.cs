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
        private readonly IRequestContextService _requestContextService;
        private readonly IMapper _mapper;
        private readonly IStorageService _storageService;

        public GetMeQueryHandler(
          IRequestContextService requestContextService,
          IStorageService storageService,
          IMapper mapper)
        {
            _requestContextService = requestContextService;
            _mapper = mapper;
            _storageService = storageService;

        }

        public Task<GetMeResponse> Handle(GetMeQuery request, CancellationToken cancellationToken)
        {
            var user = _requestContextService.User;
            var userDto = _mapper.Map<GetMeResponse>(user);

            if (user?.Avatar != null)
            {
                userDto.Avatar = _storageService.GetUrl(user.Avatar);
            }
            return Task.FromResult(userDto);
        }
    }

}
