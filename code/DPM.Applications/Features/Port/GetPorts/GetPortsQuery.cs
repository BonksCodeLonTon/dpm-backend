using MediatR;


namespace DPM.Applications.Features.Port.GetPorts
{
    public class GetPortsQuery : IRequest<IQueryable<Domain.Entities.Port>>
    {

    }
}
