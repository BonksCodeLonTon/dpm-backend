using DPM.Domain.Entities;
using MediatR;


namespace DPM.Applications.Features.SailingRegister.GetDepartRegistrations
{
    public class GetDepartRegistrationsQuery : IRequest<IQueryable<DepartureRegistration>>
    {
    }
}
