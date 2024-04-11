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

namespace DPM.Applications.Features.Ships.UpdateShip
{
    public class UpdateShipCommand : IRequest<Ship>
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? ClassNumber { get; set; }
        public string? IMONumber { get; set; }
        public string? RegisterNumber { get; set; }
        public string? GrossTonnage { get; set; }
        public string? Length { get; set; }
        public ShipType ShipType { get; set; }
        public ShipStatus ShipStatus { get; set; }
        public long? OwnerId { get; set; }
        public string? ImagePath { get; set; }

    }
    public class UpdateShipCommandProfile : Profile
    {
        public UpdateShipCommandProfile()
        {
            CreateMap<UpdateShipCommand, Ship>();
        }
    }
    public class UpdateShipCommandValidator : AbstractValidator<UpdateShipCommand>
    {
        public UpdateShipCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.ClassNumber).NotEmpty().MaximumLength(50);
            RuleFor(x => x.IMONumber).NotEmpty().MaximumLength(50);
            RuleFor(x => x.RegisterNumber).NotEmpty().MaximumLength(50);
        }
    }
}
