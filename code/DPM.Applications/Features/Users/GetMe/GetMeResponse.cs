using AutoMapper;
using DPM.Domain.Entities;
using DPM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Users.GetMe
{
    public class GetMeResponse
    {
        public long Id { get; set; }
        public string Email { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public Gender? Gender { get; set; }
        public string? Avatar { get; set; }
        public string RoleType { get; set; } = default!;
    }
    public class GetMeResponseProfile : Profile
    {
        public GetMeResponseProfile()
        {
            CreateMap<User, GetMeResponse>();
        }
    }

}
