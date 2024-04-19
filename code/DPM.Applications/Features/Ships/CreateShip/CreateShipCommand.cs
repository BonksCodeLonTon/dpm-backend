using AutoMapper;
using DPM.Domain.Entities;
using DPM.Domain.Enums;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Ships.CreateShip
{
    public class CreateShipCommand : IRequest<Ship>
    {
        public string Name { get; set; } = default!;
        public string ClassNumber { get; set; } = default!;
        public string IMONumber { get; set; }  = default!;
        public string Length { get; set; } = default!;
        public ShipType ShipType { get; set; }
        public string RegisterNumber { get; set; } = default!;
        public string GrossTonnage { get; set; } = default!;
        public long OwnerId { get; set; } = default!;
        public string? ImagePath { get; set; }

    }
    public class CreateShipCommandProfile : Profile
    {
        public CreateShipCommandProfile()
        {
            CreateMap<CreateShipCommand, Ship>();
        }
    }
    public class CreateShipCommandValidator : AbstractValidator<CreateShipCommand>
    {
        public CreateShipCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.ClassNumber).NotEmpty().MaximumLength(50);
            RuleFor(x => x.IMONumber).NotEmpty().MaximumLength(50);
            RuleFor(x => x.RegisterNumber).NotEmpty().MaximumLength(50);
        }
    }
}
