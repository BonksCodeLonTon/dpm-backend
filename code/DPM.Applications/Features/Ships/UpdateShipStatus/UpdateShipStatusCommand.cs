﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Ships.UpdateShipStatus
{
    public class UpdateShipStatusCommand  : IRequest<bool>
    {
        public long Id { get; set; }
        public bool IsDisabled { get; set; }
    }
}
