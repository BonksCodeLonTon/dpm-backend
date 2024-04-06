using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.ShipCertificates.GetCertificatesByShipId
{
    public class GetCertificatesByShipIdQueryHandler : IRequestHandler<GetCertificatesByShipIdQuery, IQueryable<ShipCertificate>>
    {
        private readonly IShipCertificateRepository _shipCertificateRepository;

        public GetCertificatesByShipIdQueryHandler(IShipCertificateRepository shipCertificateRepository)
        {
            _shipCertificateRepository = shipCertificateRepository;
        }

        public Task<IQueryable<ShipCertificate>> Handle(GetCertificatesByShipIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_shipCertificateRepository.GetAll(ReadConsistency.Cached).Where(sc => sc.ShipId == request.ShipId));
        }
    }
}
