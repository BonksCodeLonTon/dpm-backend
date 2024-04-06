using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.PortAuthorityUsers.Admin.RemovePortAuthorityUser
{
    public class RemovePortAuthorityUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
    public class RemovePortAuthorityUserCommandValidator : AbstractValidator<RemovePortAuthorityUserCommand>
    {
        public RemovePortAuthorityUserCommandValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
        }
    }
}
