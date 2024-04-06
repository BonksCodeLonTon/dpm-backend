using DPM.Domain.Common.Models;
using DPM.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Domain.Entities
{
    public class User : BaseEntity, ISoftDeletableEntity, IAuditableEntity
    {
        public string CognitoSub { get; set; } = default!;
        public string? FullName { get; set; }
        public DateTime? DateOfBirth { get;set; }
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
        public bool IsDisabled { get; set; }
        public bool IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public User? Creator { get; set; }
        public User? Updater { get; set; }
    }

}
