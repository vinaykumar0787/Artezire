using System;

namespace Artezire.Data.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
