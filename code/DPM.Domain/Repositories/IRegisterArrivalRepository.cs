using DPM.Domain.Common;
using DPM.Domain.Common.Interfaces;
using DPM.Domain.Entities;
namespace DPM.Domain.Repositories
{
    public interface IRegisterArrivalRepository : IGenericRepository<ArrivalRegistration>
    {
        ArrivalRegistration GetByStringId(string id,
            ReadConsistency readConsistency = ReadConsistency.Strong,
            bool tracking = false,
            params string[] relations);
/*        IQueryable<ArrivalRegistration> GetAllArrivalRegistrationWithRelations(
        ReadConsistency readConsistency = ReadConsistency.Strong,
        bool tracking = false,
        params string[] relations);*/
    }
}
