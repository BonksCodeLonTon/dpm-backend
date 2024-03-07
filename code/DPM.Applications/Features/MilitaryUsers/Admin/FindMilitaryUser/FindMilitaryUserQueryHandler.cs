using DPM.Domain.Entities;
using DPM.Domain.Enums;
using DPM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.MilitaryUsers.Admin.FindMilitaryUser
{
    public class FindMilitaryUserQueryHandler : IRequestHandler<FindMilitaryUserQuery, IQueryable<User>>
    {
        private readonly IUserRepository _userRepository;

        public FindMilitaryUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IQueryable<User>> Handle(FindMilitaryUserQuery request, CancellationToken cancellationToken)
        {
            IQueryable<User> users = _userRepository.Find(request.Query);

            users = users.Where(u => u.Role == Role.Military);

            return Task.FromResult(users);
        }
    }
}
