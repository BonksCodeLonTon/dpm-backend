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

namespace DPM.Applications.Features.Auth.SignUp
{
    public class SignUpCommand : IRequest<string>
    {
        public string Email { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string? PhoneNumber { get; set; }
    }
    public class SignUpCommandValidator : AbstractValidator<SignUpCommand>
    {
        public SignUpCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(v => v.PhoneNumber).NotEmpty()
              .Must(x =>
                  x == null ||
                  Regex.IsMatch(x, Regexps.PhoneNumber))
              .MaximumLength(16);
        }
    }

    public class SignUpCommandProfile : Profile
    {
        public SignUpCommandProfile()
        {
            CreateMap<SignUpCommand, User>();
        }
    }

}
