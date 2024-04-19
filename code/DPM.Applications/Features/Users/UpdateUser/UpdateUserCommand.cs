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

namespace DPM.Applications.Features.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public string? FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public Gender? Gender { get; set; }
        public Countries Country { get; set; }
        public string NationalId { get; set; }
        public string? Avatar { get; set; }
        public RoleType RoleType { get; set; }
        public Role Role { get; set; }
    }
    public class UUpdateUserCommandProfile : Profile
    {
        public UUpdateUserCommandProfile()
        {
            CreateMap<UpdateUserCommand, User>();
        }
    }

    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
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
