using DPM.Domain.Entities;
using MediatR;

namespace DPM.Applications.Features.Users.GetOwnerUsers
{
    public class GetOwnerUsersQuery : IRequest<IQueryable<User>>
    {
    }
}
