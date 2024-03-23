using DPM.Domain.Entities;
using MediatR;

namespace DPM.Applications.Features.SailingRegister.GetArrivalRegistations
{
    public class GetArrivalRegistationsQuery : IRequest<IQueryable<ArrivalRegistration>>
    {
    }
}
