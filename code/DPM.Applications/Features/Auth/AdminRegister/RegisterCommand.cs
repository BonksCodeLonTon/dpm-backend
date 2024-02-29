using FluentValidation;
using MediatR;
using AutoMapper;
using System.Text.RegularExpressions;
using DPM.Domain.Enums;
using DPM.Applications.Common;
using DPM.Domain.Entities;
using DPM.Applications.Features.Auth.Register;

namespace DPM.Domain.Features.Auth.Register
{
    public class RegisterCommand : IRequest<RegisterResponse>
    {
        public string Email { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string? PhoneNumber { get; set; }
        public Gender? Gender { get; set; }
        public string? Avatar { get; set; }
    }

    public class RequestCommandValidator : AbstractValidator<RegisterCommand>
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
            CreateMap<RegisterCommand, User>();
        }
    }
}
