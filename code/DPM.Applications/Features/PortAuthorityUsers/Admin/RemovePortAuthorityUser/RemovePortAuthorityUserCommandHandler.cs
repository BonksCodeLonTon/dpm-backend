using DPM.Domain.Repositories;
using MediatR;

namespace DPM.Applications.Features.PortAuthorityUsers.Admin.RemovePortAuthorityUser
{
    internal class RemovePortAuthorityUserCommandHandler : IRequestHandler<RemovePortAuthorityUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public RemovePortAuthorityUserCommandHandler(
          IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RemovePortAuthorityUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository
              .GetAll(tracking: true)
              .FirstOrDefault(u => u.Id == request.Id);

            if (user == null)
            {
                return false;
            }
            user.Role = Domain.Enums.Role.None;
            await _userRepository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
