using Core.Entities;
using Core.Interfaces;

namespace Data.Entities
{
    public class UserEntity : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string PasswordHash { get; set; }
        public string Role { get; set; } 
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}
