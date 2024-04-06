using DPM.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.SailingRegister.GetDepartureRegistrationById
{
    public class GetDepartureRegistrationByIdQuery : IRequest<DepartureRegistration>
    {
        public string? Id { get; set; }

    }
    public class GetDepartureRegistrationByIdQueryValidator : AbstractValidator<DepartureRegistration>
    {
        public GetDepartureRegistrationByIdQueryValidator()
        {
            RuleFor(x => x.ShipId).NotEmpty();
        }
    }
}
