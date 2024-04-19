using DPM.Domain.Common;
using DPM.Domain.Common.Interfaces;
using DPM.Domain.Entities;

namespace DPM.Domain.Repositories
{
    public interface IRegisterDepartureRepository : IGenericRepository<DepartureRegistration>
    {
        DepartureRegistration GetByStringId(string id,
            ReadConsistency readConsistency = ReadConsistency.Strong,
            bool tracking = false,
            params string[] relations);
/*        IQueryable<DepartureRegistration> GetAllDepartureRegistrationWithRelations(
        ReadConsistency readConsistency = ReadConsistency.Strong,
        bool tracking = false,
        params string[] relations);*/
    }
}
