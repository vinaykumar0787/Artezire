


using IdentityServer4.Models;
using System.Collections.Generic;

namespace QuickstartIdentityServer
{
    using IdentityServer4;
    using System.Security.Claims;
    using static IdentityServer4.IdentityServerConstants;

    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource("dataeventrecordsscope",new []{ "role", "admin", "user","apis" })
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("apis")
                {
                    ApiSecrets =
                    {
                        new Secret("apisecret".Sha256())
                    },
                    Scopes =
                    {
                        new Scope
                        {
                            Name = "apis",
                            DisplayName = "Scope for the ApiResource"
                        }
                    },
                    UserClaims = { "role", "admin", "user", "apis" }
                }
            };
        }

        //Scope
        public static IEnumerable<Scope> GetScopes()
        {
            return new List<Scope>
            {
                new Scope(StandardScopes.OpenId),
                new Scope(StandardScopes.Profile),
                new Scope(StandardScopes.OfflineAccess),
                new Scope {Name = "apis", DisplayName = "apis"}
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {

                new Client
                {
                    ClientName = "angular2client",
                    ClientId = "angular2client",
                    AccessTokenType = AccessTokenType.Reference,
                    //AccessTokenLifetime = 600, // 10 minutes, default 60 minutes
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        "http://localhost:4200"

                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:4200/Unauthorized"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        "http://localhost:4200",
                        "http://localhost:3000"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "apis",
                        "role"
                    }
                }
                //new Client
                //{
                //    ClientName = "angular2client",
                //    ClientId = "angular2client",
                //    ClientSecrets = new List<Secret>
                //    {
                //        new Secret("apisecret".Sha256())
                //    },
                //    AccessTokenType = AccessTokenType.Jwt,
                //    //AccessTokenLifetime = 600, // 10 minutes, default 60 minutes
                //    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                //    AllowAccessTokensViaBrowser = true,
                //    //RedirectUris = new List<string>
                //    //{
                //    //    "https://localhost:3000"

                //    //},
                //    //PostLogoutRedirectUris = new List<string>
                //    //{
                //    //    "https://localhost:3000/Unauthorized"
                //    //},
                //    //AllowedCorsOrigins = new List<string>
                //    //{
                //    //    "https://localhost:3000",
                //    //    "http://localhost:3000"
                //    //},
                //    AllowedScopes = new List<string>
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "apis",
                //        "role"
                //    }
                //}
            };
        }
    }
}