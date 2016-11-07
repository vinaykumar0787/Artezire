using System;
using System.ComponentModel.DataAnnotations;

namespace Artezire.Data.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryCode { get; set; }
        public int PhoneNumber { get; set; }
        public int GenderId { get; set; }
        public int UserTypeId { get; set; }
        public int UserStatusId { get; set; }
        public short IsValidUser { get; set; }

        public Gender Gender { get; set; }
        public UserType UserType { get; set; }
        public UserStatus UserStatus { get; set; }
    }
}
