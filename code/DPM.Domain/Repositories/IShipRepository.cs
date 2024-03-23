using DPM.Domain.Common.Interfaces;
using DPM.Domain.Entities;


namespace DPM.Domain.Repositories
{
    public interface IShipRepository : IGenericRepository<Ship>
    {
        public IEnumerable<Ship> GetAllShipWithRelatedUserAsync(long userId);
    }
}
