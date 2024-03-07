using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using DPM.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.MilitaryUsers.Admin.GetMilitaryUsers
{
    public class GetMilitaryUserQueryHandler : IRequestHandler<GetMilitaryUsersQuery, IQueryable<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetMilitaryUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IQueryable<User>> Handle(GetMilitaryUsersQuery request, CancellationToken cancellationToken)
        {
            IQueryable<User> users = _userRepository.GetAll(ReadConsistency.Eventual);

            users = users.Where(u => u.Role == Role.Military);

            return Task.FromResult(users);
        }

    }
}
