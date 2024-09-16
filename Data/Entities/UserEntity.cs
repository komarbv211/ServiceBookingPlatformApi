using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Data.Entities
{
    public class UserEntity : IdentityUser
    {
        public DateTime? Birthdate { get; set; }
        public string? Role { get; set; } 
        public DateTime CreatedDate { get; set; } 
        public DateTime LastLoginDate { get; set; }
    }
}
