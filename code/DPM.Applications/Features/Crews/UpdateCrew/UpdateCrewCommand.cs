using AutoMapper;
using DPM.Applications.Common;
using DPM.Domain.Entities;
using DPM.Domain.Enums;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Crews.UpdateCrew
{
    public class UpdateCrewCommand : IRequest<Crew>
    {
        public long Id { get; set; }
        public string? Fullname { get; set; }
        public Countries Countries { get; set; }
        public string? NationalId { get; set; }
        public string? YearExperience { get; set; }
        public string RelativePhoneNumber { get; set; }
    }
    public class UpdateCrewCommandProfile : Profile
    {
        public UpdateCrewCommandProfile()
        {
            CreateMap<UpdateCrewCommand, Ship>();
        }
    }
    public class UpdateShipCommandValidator : AbstractValidator<UpdateCrewCommand>
    {
        public UpdateShipCommandValidator()
        {
            RuleFor(v => v.NationalId)
              .Must(x =>
                  x == null ||
                  Regex.IsMatch(x, Regexps.NationalId));
        }
    }
}
