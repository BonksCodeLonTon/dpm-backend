using AutoMapper;
using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;

namespace DPM.Applications.Features.Users.UpdateUser
{
    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IRequestContextService _requestContextService;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IRequestContextService requestContextService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _requestContextService = requestContextService;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userId = request.Id;
            var user = _userRepository.GetById(userId, tracking: true)
              ?? throw new NotFoundException(nameof(User));

            _mapper.Map(request, user);
            await _userRepository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
