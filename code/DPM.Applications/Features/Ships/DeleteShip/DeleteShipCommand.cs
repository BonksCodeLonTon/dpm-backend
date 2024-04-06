using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Ships.DeleteShip
{
    public class DeleteShipCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
    public class DeleteShipCommandValidator : AbstractValidator<DeleteShipCommand>
    {
        public DeleteShipCommandValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
        }
    }
}
