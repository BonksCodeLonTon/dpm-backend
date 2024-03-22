using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.MilitaryUsers.Admin.RemoveMilitaryUser
{
    public class RemoveMilitaryUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
    public class DeleteOrganizationCommandValidator : AbstractValidator<RemoveMilitaryUserCommand>
    {
        public DeleteOrganizationCommandValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
        }
    }
}
