using AutoMapper;
using DPM.Applications.Common;
using DPM.Domain.Entities;
using DPM.Domain.Enums;
using FluentValidation;
using MediatR;
using System.Text.RegularExpressions;


namespace DPM.Applications.Features.MilitaryUsers.Admin.CreateMilitaryUser
{
    public class CreateMilitaryUserCommand : IRequest<CreateMilitaryUserResponse>
    {
        public string Email { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string? PhoneNumber { get; set; }
        public Gender? Gender { get; set; }
        public string? Avatar { get; set; }

    }
    public class RequestCommandValidator : AbstractValidator<CreateMilitaryUserCommand>
    {
        public RequestCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(v => v.PhoneNumber).NotEmpty()
              .Must(x =>
                  x == null ||
                  Regex.IsMatch(x, Regexps.PhoneNumber))
              .MaximumLength(16);
        }
    }

    public class RegisterCommandProfile : Profile
    {
        public RegisterCommandProfile()
        {
            CreateMap<CreateMilitaryUserCommand, User>();
        }
    }
}
