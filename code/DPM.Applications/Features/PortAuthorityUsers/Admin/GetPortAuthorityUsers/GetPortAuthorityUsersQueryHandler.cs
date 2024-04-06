using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Enums;
using DPM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.PortAuthorityUsers.Admin.GetPortAuthorityUsers
{
    internal class GetPortAuthorityUsersQueryHandler : IRequestHandler< GetPortAuthorityUsersQuery, IQueryable<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetPortAuthorityUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IQueryable<User>> Handle( GetPortAuthorityUsersQuery request, CancellationToken cancellationToken)
        {
            IQueryable<User> users = _userRepository.GetAll(ReadConsistency.Eventual);

            users = users.Where(u => u.Role == Role.PortAuthority);

            return Task.FromResult(users);
        }

    }
}
