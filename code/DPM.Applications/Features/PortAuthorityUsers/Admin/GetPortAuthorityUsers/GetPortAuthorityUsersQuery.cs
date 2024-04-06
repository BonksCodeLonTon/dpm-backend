using DPM.Domain.Entities;
using MediatR;

namespace DPM.Applications.Features.PortAuthorityUsers.Admin.GetPortAuthorityUsers
{
    public class GetPortAuthorityUsersQuery : IRequest<IQueryable<User>>
    {
    }
}
