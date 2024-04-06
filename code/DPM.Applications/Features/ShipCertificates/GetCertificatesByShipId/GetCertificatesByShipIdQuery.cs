using DPM.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.ShipCertificates.GetCertificatesByShipId
{
    public class GetCertificatesByShipIdQuery : IRequest<IQueryable<ShipCertificate>>
    {
        public long? ShipId { get; set; }
    }
}
