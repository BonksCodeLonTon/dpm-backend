using DPM.Domain.Entities;
using MediatR;

namespace DPM.Applications.Features.Users.FindUsers
{
    public class FindUsersQuery : IRequest<IQueryable<User>>
    {
        public string Query { get; set; } = default!;
    }
}
