using DPM.Domain.Entities;
using DPM.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.SailingRegister.GetDepartRegistrationsWithStatus
{
    public class GetDepartRegistrationsWithStatusQuery : IRequest<IQueryable<DepartureRegistration>>
    {
        public ApproveStatus Status { get; set; }
    }
}
