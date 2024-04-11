using DevExpress.Pdf;
using DPM.Applications.Common;
using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PdfSignature = DPM.Domain.Common.Models.PdfSignature;

namespace DPM.Applications.Features.PortAuthorityUsers.PortAuthorityDepartApprove
{
    internal class PortAuthorityDepartApproveCommandHandler : IRequestHandler<PortAuthorityDepartApproveCommand, bool>
    {
        private readonly IRequestContextService _requestContextService;
        private readonly IRegisterDepartureRepository _registerDepartureRepository;
        private readonly IShipRepository _shipRepository;
        private readonly IStorageService _storageService;
        private readonly IDigitalSigningService _digitalSigningService;
        public PortAuthorityDepartApproveCommandHandler(
            IRequestContextService requestContextService,
            IRegisterDepartureRepository registerDepartureRepository,
            IStorageService storageService,
            IShipRepository shipRepository,
            IDigitalSigningService digitalSigningService)
        {
            _requestContextService = requestContextService;
            _registerDepartureRepository = registerDepartureRepository;
            _storageService = storageService;
            _shipRepository = shipRepository;
            _digitalSigningService = digitalSigningService;
        }

        public async Task<bool> Handle(PortAuthorityDepartApproveCommand request, CancellationToken cancellationToken)
        {
            var departureRegistration = await _registerDepartureRepository
                .GetAll(tracking: true)
                .FirstOrDefaultAsync(u => u.DepartureId == request.DepartureId, cancellationToken)
                ?? throw new NotFoundException(nameof(ArrivalRegistration));
            var fullName = _requestContextService.User.FullName;
            var ship = _shipRepository.GetById(departureRegistration.ShipId);

            var attachmentContent = await _storageService.GetObject(departureRegistration.Attachment)
                ?? throw new NotFoundException(nameof(ArrivalRegistration));

            using (var attachmentContentStream = await _storageService.DownloadAsync(departureRegistration.Attachment))
            {
                PdfSignature militarySignature = new PdfSignature
                {
                    FullName = fullName,
                    FieldName = Constants.PortAuthoritySigningField,
                    Location = new PdfRectangle(325, 275, 550, 350),
                    Reason = string.Format(Constants.ArriveApprove, ship.Name),
                };

                await _digitalSigningService.SignAsync(attachmentContent, departureRegistration.Attachment, militarySignature);
            }

            departureRegistration.ApproveStatus = departureRegistration.ApproveStatus == Domain.Enums.ApproveStatus.ApprovedByMilitary
                ? Domain.Enums.ApproveStatus.Approved
                : Domain.Enums.ApproveStatus.ApprovedByPortAuthority;

            await _registerDepartureRepository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
