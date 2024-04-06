using MediatR;
using DPM.Domain.Entities;
using DPM.Domain.Enums;
using AutoMapper;
using FluentValidation;
namespace DPM.Applications.Features.Crews.CreateCrew
{
    public class CreateCrewCommand : IRequest<Crew>
    {
        public string? Fullname { get; set; }
        public Countries Countries { get; set; } = Countries.VN;
        public string? NationalId { get; set; }
        public string? YearExperience { get; set; }
        public string RelativePhoneNumber { get; set; }

    }
    public class CreateCrewCommandProfile : Profile
    {
        public CreateCrewCommandProfile()
        {
            CreateMap<CreateCrewCommand, Crew>();
        }
    }
    public class CreateCrewCommandValidator : AbstractValidator<CreateCrewCommand>
    {
        public CreateCrewCommandValidator()
        {
            RuleFor(x => x.Fullname).NotEmpty().MaximumLength(100);
            RuleFor(x => x.NationalId).NotEmpty().MaximumLength(50);
            RuleFor(x => x.YearExperience).NotEmpty();
        }
    }
}
