using DPM.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Ships.GetShips
{
    public class GetShipsQuery : IRequest<IQueryable<Ship>>
    {
    }
}
