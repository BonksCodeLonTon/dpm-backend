using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Users.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IQueryable<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IQueryable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_userRepository.GetAll(ReadConsistency.Eventual));
        }
    }
}
