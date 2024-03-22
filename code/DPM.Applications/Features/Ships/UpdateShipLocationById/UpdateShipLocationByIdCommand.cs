using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Ships.UpdateShipLocationById
{
    public class UpdateShipLocationByIdCommand: IRequest<bool>
    {
        public long Id { get; set; }
        public long[] Position { get; set; }
    }
}
