using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Port.GetPort
{
    public class GetPortQuery : IRequest<IQueryable<Domain.Entities.Port>>
    {
        public long Id { get; set; }
    }
}
