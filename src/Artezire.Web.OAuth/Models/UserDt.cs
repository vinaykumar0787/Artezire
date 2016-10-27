using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artezire.Web.OAuth.Models
{
    public class UserDt
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
