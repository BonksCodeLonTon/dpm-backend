using DPM.Domain.Entities;
using MediatR;

namespace DPM.Applications.Features.Users.GetCaptainUsers
{
    public class GetCaptainUsersQuery  : IRequest<IQueryable<User>>
    {
    }
}
