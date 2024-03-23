using Autofac;
using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;

namespace DPM.Infrastructure.Database.Repositories
{
    internal class ShipRepository : GenericRepository<Ship>, IShipRepository
    {
        private readonly IUserRepository _userRepository;

        public ShipRepository(ILifetimeScope scope) : base(scope)
        {
            _userRepository = scope.Resolve<IUserRepository>();
        }
        public IEnumerable<Ship> GetAllShipWithRelatedUserAsync(long userId)
        {
            var user = _userRepository.GetById(userId);

            if (user == null)
            {
                return Enumerable.Empty<Ship>();
            }
            var result = GetAll(ReadConsistency.Eventual)
                .Where(ship => ship.OwnerId == user.Id) 
                .ToList(); 

            return result;
        }

    }
}