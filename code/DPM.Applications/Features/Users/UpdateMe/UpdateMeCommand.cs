using DPM.Domain.Enums;
using MediatR;
using AutoMapper;
using FluentValidation;
using System.Text.RegularExpressions;
using DPM.Applications.Common;
using DPM.Domain.Entities;

namespace DPM.Applications.Features.Users.UpdateMe
{
    public class UpdateMeCommand : IRequest<User>
    {
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public Gender? Gender { get; set; }
        public string? Avatar { get; set; }
        public string? Address { get; set; }
    }
    public class UpdateMeCommandProfile : Profile
    {
        public UpdateMeCommandProfile()
        {
            CreateMap<UpdateMeCommand, User>();
        }
    }

    public class UpdateMeCommandValidator : AbstractValidator<UpdateMeCommand>
    {
        public UpdateMeCommandValidator()
        {
            RuleFor(v => v.Address).MaximumLength(256);
            RuleFor(v => v.FullName).MaximumLength(64);
            RuleFor(v => v.PhoneNumber)
              .Must(x =>
                  x == null ||
                  Regex.IsMatch(x, Regexps.PhoneNumber))
              .MaximumLength(16);
        }
    }
}
