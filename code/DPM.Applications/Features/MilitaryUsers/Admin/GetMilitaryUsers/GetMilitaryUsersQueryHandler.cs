using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using DPM.Domain.Enums;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DPM.Applications.Features.MilitaryUsers.Admin.GetMilitaryUsers
{
    public class GetMilitaryUsersQueryHandler : IRequestHandler<GetMilitaryUsersQuery, IQueryable<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetMilitaryUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IQueryable<User>> Handle(GetMilitaryUsersQuery request, CancellationToken cancellationToken)
        {
            IQueryable<User> users =  _userRepository.GetAll(ReadConsistency.Cached);
            return Task.FromResult(users.Where(u => u.Role == Role.Military));
        }
    }
}