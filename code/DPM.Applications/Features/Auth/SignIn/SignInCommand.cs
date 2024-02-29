using AutoMapper;
using DPM.Applications.Common;
using DPM.Domain.Entities;
using DPM.Domain.Enums;
using DPM.Domain.Features.Auth.Register;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Auth.SignIn
{
    public class SignInCommand : IRequest<SignInResponse>
    {
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
