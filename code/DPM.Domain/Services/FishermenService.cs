using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DPM.Domain.Entities;
using DPM.Domain.Common.Interfaces;

namespace DPM.Domain.Services
{
    public class FishermenService : BaseService<Fishermen>, IFishermenService
    {
        private readonly IGenericRepository<Fishermen> _fishermenRepository;

        public FishermenService(IGenericRepository<Fishermen> fishermenRepository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _fishermenRepository = fishermenRepository ?? throw new ArgumentNullException(nameof(fishermenRepository));
        }

        public IEnumerable<Fishermen> GetAllFishermen()
        {
            return _fishermenRepository.GetAll();
        }

        public Fishermen GetFishermanById(long id)
        {
            return _fishermenRepository.GetById(id);
        }

        public async Task AddFisherman(Fishermen fisherman)
        {
            if (fisherman == null)
            {
                throw new ArgumentNullException(nameof(fisherman));
            }

            _fishermenRepository.Add(fisherman);
            await UnitOfWork.CommitAsync();
        }

        public async Task UpdateFisherman(Fishermen fisherman)
        {
            if (fisherman == null)
            {
                throw new ArgumentNullException(nameof(fisherman));
            }

            _fishermenRepository.Update(fisherman);
            await UnitOfWork.CommitAsync();
        }

        public async Task DeleteFisherman(long id)
        {
            var fisherman = _fishermenRepository.GetById(id);

            if (fisherman != null)
            {
                _fishermenRepository.Delete(fisherman);
                await UnitOfWork.CommitAsync();
            }
        }
    }
}
