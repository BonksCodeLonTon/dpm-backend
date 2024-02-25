using AutoMapper;
using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Users.UpdateMe
{
    public class UpdateMeCommandHandler : IRequestHandler<UpdateMeCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IRequestContextService _requestContextService;

        public UpdateMeCommandHandler(IUserRepository userRepository, IMapper mapper, IRequestContextService requestContextService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _requestContextService = requestContextService;
        }

        public async Task<User> Handle(UpdateMeCommand request, CancellationToken cancellationToken)
        {
            var userId = _requestContextService.UserId;
            var user = _userRepository.GetById(userId, tracking: true)
              ?? throw new NotFoundException(nameof(User));

            _mapper.Map(request, user);
            await _userRepository.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}
