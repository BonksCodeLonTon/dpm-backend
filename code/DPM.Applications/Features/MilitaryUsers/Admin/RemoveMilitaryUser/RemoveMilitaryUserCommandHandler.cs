using DPM.Applications.Services;
using DPM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.MilitaryUsers.Admin.RemoveMilitaryUser
{
    public class RemoveMilitaryUserCommandHandler : IRequestHandler<RemoveMilitaryUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public RemoveMilitaryUserCommandHandler(
          IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RemoveMilitaryUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository
              .GetAll(tracking: true)
              .FirstOrDefault( u => u.Id == request.Id);

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
