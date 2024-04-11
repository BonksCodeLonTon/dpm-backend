using MediatR;

namespace DPM.Applications.Features.SailingRegister.UpdateDepartureRegistrationById
{
    public class UpdateDepartureRegistrationByIdCommand : IRequest<bool>
    {
        public string DepartureId { get; set; }
        public string Attachment { get; set; }
    }
}
