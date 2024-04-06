using FluentValidation;
using MediatR;

namespace DPM.Applications.Features.MilitaryUsers.Admin.RemoveMilitaryUser
{
    public class RemoveMilitaryUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
    public class RemoveMilitaryUserCommandValidator : AbstractValidator<RemoveMilitaryUserCommand>
    {
        public RemoveMilitaryUserCommandValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
        }
    }
}
