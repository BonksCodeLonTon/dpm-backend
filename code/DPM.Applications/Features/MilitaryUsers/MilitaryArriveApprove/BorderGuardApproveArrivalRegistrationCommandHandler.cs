using DevExpress.Pdf;
using DPM.Applications.Common;
using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PdfSignature = DPM.Domain.Common.Models.PdfSignature;

namespace DPM.Applications.Features.MilitaryUsers.MilitaryArriveApprove
{
    internal class BorderGuardApproveArrivalRegistrationCommandHandler : IRequestHandler<BorderGuardApproveArrivalRegistrationCommand, bool>
    {
        private readonly IRequestContextService _requestContextService;
        private readonly IRegisterArrivalRepository _registerArrivalRepository;
        private readonly IShipRepository _shipRepository;
        private readonly IStorageService _storageService;
        private readonly IDigitalSigningService _digitalSigningService;

        public BorderGuardApproveArrivalRegistrationCommandHandler(
            IRequestContextService requestContextService,
            IRegisterArrivalRepository registerArrivalRepository,
            IStorageService storageService,
            IShipRepository shipRepository,
            IDigitalSigningService digitalSigningService)
        {
            _requestContextService = requestContextService;
            _registerArrivalRepository = registerArrivalRepository;
            _storageService = storageService;
            _shipRepository = shipRepository;
            _digitalSigningService = digitalSigningService;
        }

        public async Task<bool> Handle(BorderGuardApproveArrivalRegistrationCommand request, CancellationToken cancellationToken)
        {
            var arrivalRegistration = await _registerArrivalRepository
                .GetAll(tracking: true)
                .FirstOrDefaultAsync(u => u.ArrivalId == request.ArrivalId, cancellationToken)
                ?? throw new NotFoundException(nameof(ArrivalRegistration));
            var fullName = _requestContextService.User.FullName;
            var ship = _shipRepository.GetById(arrivalRegistration.ShipId);

            var attachmentContent = await _storageService.GetObject(arrivalRegistration.Attachment)
                ?? throw new NotFoundException(nameof(ArrivalRegistration));

            using (var attachmentContentStream = await _storageService.DownloadAsync(arrivalRegistration.Attachment))
            {
                PdfSignature militarySignature = new PdfSignature
                {
                    FullName = fullName,
                    FieldName = Constants.MilitarySigningField,
                    Location = new PdfRectangle(75, 275, 300, 350),
                    Reason = string.Format(Constants.ArriveApprove, ship.Name),
                };

                await _digitalSigningService.SignAsync(attachmentContent, arrivalRegistration.Attachment,  militarySignature);
            }

            arrivalRegistration.ApproveStatus = arrivalRegistration.ApproveStatus == Domain.Enums.ApproveStatus.ApprovedByPortAuthority
                ? Domain.Enums.ApproveStatus.Approved
                : Domain.Enums.ApproveStatus.ApprovedByMilitary;

            await _registerArrivalRepository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
