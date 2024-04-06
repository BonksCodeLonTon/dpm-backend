using AutoMapper;
using DPM.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.SailingRegister.GetArrivalRegistrationById
{
    public class GetArrivalRegistrationByIdQuery : IRequest<ArrivalRegistration>
    {
        public string? Id { get; set; }

    }
    public class GetArrivalRegistrationByIdQueryValidator : AbstractValidator<ArrivalRegistration>
    {
        public GetArrivalRegistrationByIdQueryValidator()
        {
            RuleFor(x => x.ShipId).NotEmpty();
        }
    }
}
