using Artezire.Web.OAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Artezire.Web.OAuth.Interfaces
{
    public interface IUserManager
    {
        Task<UserDt> FindByNameAsync(string userName);
        Task<bool> CheckPasswordAsync(UserDt user, string password);
        Task<List<Claim>> GetClaimsAsync(UserDt user);
        List<UserDt> GetUsers();
    }
}
