using DPM.Applications.Features.Users.GetUsers;
using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DPM.Applications.Features.Users.GetOwnerUsers
{
    internal class GetOwnerUsersQueryHandler : IRequestHandler<GetOwnerUsersQuery, IQueryable<User>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IShipRepository _shipRepository;

        public GetOwnerUsersQueryHandler(IUserRepository userRepository, IShipRepository shipRepository)
        {
            _userRepository = userRepository;
            _shipRepository = shipRepository;
        }

        public async Task<IQueryable<User>> Handle(GetOwnerUsersQuery request, CancellationToken cancellationToken)
        {
            var allUsers = _userRepository.GetAll(ReadConsistency.Eventual);

            var ownerIds = await _shipRepository.GetAll(ReadConsistency.Eventual)
                .Where(x => x.OwnerId != null)
                .Select(x => x.OwnerId)
                .Distinct()
                .ToListAsync(cancellationToken);

            var captainIds = ownerIds.Concat(ownerIds).Distinct().ToList();

            return allUsers.Where(u => captainIds.Contains(u.Id));
        }
    }
}
