using MediatR;


namespace DPM.Applications.Features.Users.UpdateUserStatus
{
    public class UpdateUserStatusCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public bool IsDisabled { get; set; }
    }
}
