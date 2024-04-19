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
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public Gender? Gender { get; set; }
        public string? Avatar { get; set; }
        public Countries Country { get; set; }
        public string NationalId { get; set; }
        public RoleType RoleType { get; set; } 
        public Role Role { get; set; }
    }
    public class GetMeResponseProfile : Profile
    {
        public GetMeResponseProfile()
        {
            CreateMap<User, GetMeResponse>();
        }
    }

}
