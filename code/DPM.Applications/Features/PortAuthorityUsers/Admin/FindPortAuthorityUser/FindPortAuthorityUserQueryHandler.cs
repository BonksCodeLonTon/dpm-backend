using DPM.Domain.Entities;
using DPM.Domain.Enums;
using DPM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.PortAuthorityUsers.Admin.FindPortAuthorityUser
{
    internal class FindPortAuthorityUserQueryHandler : IRequestHandler<FindPortAuthorityUserQuery, IQueryable<User>>
    {
        private readonly IUserRepository _userRepository;

        public FindPortAuthorityUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IQueryable<User>> Handle(FindPortAuthorityUserQuery request, CancellationToken cancellationToken)
        {
            IQueryable<User> users = _userRepository.Find(request.Query);

            users = users.Where(u => u.Role == Role.PortAuthority);

            return Task.FromResult(users);
        }
    }
}
