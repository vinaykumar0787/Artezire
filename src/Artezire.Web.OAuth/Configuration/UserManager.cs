using Artezire.Web.OAuth.Interfaces;
using Artezire.Web.OAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Artezire.Web.OAuth.Configuration
{
    public class UserManager : IUserManager
    {
        public Task<UserDt> FindByNameAsync(string userName)
        {
            //User db calls
            var user = GetUsers().SingleOrDefault(u => u.UserName == userName);

            return Task.FromResult(user);
        }

        public Task<bool> CheckPasswordAsync(UserDt user, string password)
        {
            //Call a Hash method to verify password
            //var isPasswordMatch = MyPasswordHasher.VerifyHashPassword(user.PasswordHash, password);

            if(user.PasswordHash == password)
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        public Task<List<Claim>> GetClaimsAsync(UserDt user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("email",user.Email));

            return Task.FromResult(claims);
        }

        public List<UserDt> GetUsers()
        {
            var users = new List<UserDt>();

            users.Add(new UserDt { UserName = "alice@gmail.com", PasswordHash = "alice", Email = "alice@gmail.com" });
            users.Add(new UserDt { UserName = "bob@gmail.com", PasswordHash = "bob", Email = "bob@gmail.com" });
            users.Add(new UserDt { UserName = "eve@gmail.com", PasswordHash = "eve", Email = "eve@gmail.com" });

            return users;
        }
    }
}
