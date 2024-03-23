using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Port.CreatePort
{
    public class CreatePortCommand : IRequest<Domain.Entities.Port>
    {
        public string? Name { get; set; }
    }

}
