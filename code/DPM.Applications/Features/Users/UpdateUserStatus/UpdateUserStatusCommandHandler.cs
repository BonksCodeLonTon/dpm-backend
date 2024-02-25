using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;


namespace DPM.Applications.Features.Users.UpdateUserStatus
{
    public class UpdateUserStatusCommandHandler : IRequestHandler<UpdateUserStatusCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRequestContextService _requestContextService;

        public UpdateUserStatusCommandHandler(
          IUserRepository userRepository,
          IRequestContextService requestContextService)
        {
            _userRepository = userRepository;
            _requestContextService = requestContextService;
        }

        public async Task<bool> Handle(UpdateUserStatusCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository
              .GetAll(tracking: true)
              .FirstOrDefault(u => u.Id == request.Id)
              ?? throw new NotFoundException(nameof(User));

            user.IsDisabled = request.IsDisabled;

            await _userRepository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }

}
