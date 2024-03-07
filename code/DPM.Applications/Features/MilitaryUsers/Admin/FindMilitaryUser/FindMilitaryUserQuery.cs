using DPM.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.MilitaryUsers.Admin.FindMilitaryUser
{
    public class FindMilitaryUserQuery : IRequest<IQueryable<User>>
    {
        public string Query { get; set; } = default!;
    }
}
