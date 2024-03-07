using DPM.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.MilitaryUsers.Admin.GetMilitaryUsers
{
    public class GetMilitaryUsersQuery : IRequest<IQueryable<User>>
    {
    }
}
