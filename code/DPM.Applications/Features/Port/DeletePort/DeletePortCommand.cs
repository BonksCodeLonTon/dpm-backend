using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Port.DeletePort
{
    public class DeletePortCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
