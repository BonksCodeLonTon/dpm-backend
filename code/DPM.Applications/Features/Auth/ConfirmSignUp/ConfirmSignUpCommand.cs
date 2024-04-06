using AutoMapper;
using DPM.Applications.Common;
using DPM.Applications.Features.Auth.SignUp;
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

namespace DPM.Applications.Features.Auth.ConfirmSignUp
{
    public class ConfirmSignUpCommand : IRequest<bool>
    {
        public string ConfirmationCode { get; set; } = default!;
        public string Sub { get; set; }  = default!;
        public string Email { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string FullName {  get; set; } = default!;
        public string? PhoneNumber { get; set; }
        public RoleType Role { get; set; } = RoleType.User;
        public Gender? Gender { get; set; }
        public string? Avatar { get; set; }
    }

    public class RequestCommandValidator : AbstractValidator<ConfirmSignUpCommand>
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

    public class ConfirmSignUpCommandProfile : Profile
    {
        public ConfirmSignUpCommandProfile()
        {
            CreateMap<ConfirmSignUpCommand, User>();
        }
    }
}
