using DPM.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.SailingRegister.UpdateArrivalShipStatusById
{
    public class UpdateArrivalShipStatusByIdCommand : IRequest<bool>
    {
        public string? ArrivalId { get; set; }
    }
}
