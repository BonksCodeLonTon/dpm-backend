using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Users.FindUsers
{
    public class FindUsersQueryHandler : IRequestHandler<FindUsersQuery, IQueryable<User>>
    {
        private readonly IUserRepository _userRepository;

        public FindUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IQueryable<User>> Handle(FindUsersQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_userRepository.Find(request.Query));
        }
    }
}
