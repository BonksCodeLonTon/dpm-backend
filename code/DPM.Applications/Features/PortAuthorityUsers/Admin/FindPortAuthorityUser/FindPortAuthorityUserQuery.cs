using DPM.Domain.Entities;
using MediatR;

namespace DPM.Applications.Features.PortAuthorityUsers.Admin.FindPortAuthorityUser
{
    public class FindPortAuthorityUserQuery : IRequest<IQueryable<User>>
    {
        public string Query { get; set; } = default!;
    }
}
