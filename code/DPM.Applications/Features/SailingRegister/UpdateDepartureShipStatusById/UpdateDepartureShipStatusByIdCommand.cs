using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.SailingRegister.UpdateDepartureShipStatusById
{
    public class UpdateDepartureShipStatusByIdCommand : IRequest<bool>
    {
        public string? DepartureId { get; set; }
    }
}
