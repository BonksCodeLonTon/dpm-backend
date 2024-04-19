using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PdfSignature = DPM.Domain.Common.Models.PdfSignature;
using DevExpress.Pdf;
using DPM.Applications.Common;
namespace DPM.Applications.Features.MilitaryUsers.MilitaryDepartApprove
{
    public class MilitaryDepartApproveCommandHandler : IRequestHandler<MilitaryDepartApproveCommand, bool>
    {
        private readonly IRequestContextService _requestContextService;
        private readonly IRegisterDepartureRepository _registerDepartureRepository;
        private readonly IDigitalSigningService _digitalSigningService;
        private readonly IStorageService _storageService;
        private readonly IShipRepository _shipRepository;

        public MilitaryDepartApproveCommandHandler(
          IRequestContextService requestContextService,
          IRegisterDepartureRepository registerDepartureRepository,
          IDigitalSigningService digitalSigningService,
          IShipRepository shipRepository,
          IStorageService storageService
            )
        {
            _requestContextService = requestContextService;
            _registerDepartureRepository = registerDepartureRepository;
            _digitalSigningService = digitalSigningService;
            _shipRepository = shipRepository;
            _storageService = storageService;
        }

        public async Task<bool> Handle(MilitaryDepartApproveCommand request, CancellationToken cancellationToken)
        {
            var departRegistration = await _registerDepartureRepository
                .GetAll(tracking: true)
                .FirstOrDefaultAsync(u => u.DepartureId == request.DepartureId, cancellationToken)
                ?? throw new NotFoundException(nameof(DepartureRegistration));
            var fullName = _requestContextService.User.FullName;
            var ship = _shipRepository.GetById(departRegistration.ShipId);
            var attachmentContent = await _storageService.GetObject(departRegistration.Attachment)
                ?? throw new NotFoundException(nameof(ArrivalRegistration));

            using (var attachmentContentStream = await _storageService.DownloadAsync(departRegistration.Attachment))
            {
                PdfSignature militarySignature = new PdfSignature
                {
                    FullName = fullName,
                    FieldName = Constants.MilitarySigningField,
                    Location = new PdfRectangle(75, 275, 300, 350),
                    Reason = string.Format(Constants.DepartApprove, ship.Name),
                };

                await _digitalSigningService.SignAsync(attachmentContent, departRegistration.Attachment, militarySignature);
            }

            departRegistration.ApproveStatus = departRegistration.ApproveStatus == Domain.Enums.ApproveStatus.ApprovedByPortAuthority
                ? Domain.Enums.ApproveStatus.Approved
                : Domain.Enums.ApproveStatus.ApprovedByMilitary;

            await _registerDepartureRepository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
