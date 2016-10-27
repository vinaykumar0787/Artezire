using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using IdentityModel;
using System.Threading.Tasks;
using IdentityServer4.Models;
using Artezire.Web.OAuth.Interfaces;
using Artezire.Web.OAuth.Models;
using System.Security.Claims;

namespace Artezire.Web.OAuth.Configuration
{
    public class ProfileService : IProfileService
    {
        private IUserManager _userManager;
        public ProfileService(IUserManager _userManager)
        {
            this._userManager = _userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.FindFirst("sub").Value;
            if(!String.IsNullOrEmpty(sub))
            {
                var user = await _userManager.FindByNameAsync(sub);
                var cp = await GetClaims(user);

                var claims = cp.Claims;
                if(context.AllClaimsRequested == false || (context.RequestedClaimTypes != null && context.RequestedClaimTypes.Any()))
                {
                    claims = claims.Where(x=> context.RequestedClaimTypes.Contains(x.Type)).ToList();
                }
                context.IssuedClaims = claims.ToList();
            }
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.FromResult(0);
        }

        private async Task<ClaimsPrincipal> GetClaims(UserDt user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var id = new ClaimsIdentity();
            id.AddClaim(new Claim(JwtClaimTypes.PreferredUserName, user.UserName));
            id.AddClaims(await _userManager.GetClaimsAsync(user));

            return new ClaimsPrincipal(id);
        }
    }
}
