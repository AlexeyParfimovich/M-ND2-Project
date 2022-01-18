using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MyFinance.IdentityServer
{
    public static class ISConfig
    {
        public static IEnumerable<Client> GetClients() =>
            new Client[]
            {
                //new Client()
                //{
                //    ClientId = "client_id",
                //    ClientSecrets = { new Secret("client_secret".ToSha256()) },
                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    AllowedScopes =
                //    {
                //        "MyFinanceAPI"
                //    }
                //},

                new Client()
                {
                    ClientId = "mvc_client_id",
                    ClientSecrets = { new Secret("mvc_client_secret".ToSha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes =
                    {
                        "MyFinanceAPI",
                        IdentityServerConstants.StandardScopes.OpenId, // "openid"
                        IdentityServerConstants.StandardScopes.Profile // "profile"
                    },

                    RedirectUris =
                    {
                        "https://localhost:9001/signin-oidc"
                    },

                    // Specifies whether a consent page is required
                    RequireConsent = false,

                    // Set user claims always be added to the id token
                    //AlwaysIncludeUserClaimsInIdToken = true,

                    // Lifetime of access token in seconds (defaults to 3600 seconds)
                    AccessTokenLifetime = 10,

                    // Enable Refresh Token be issued
                    AllowOfflineAccess = true,
                }

            };

        internal static IEnumerable<ApiScope> GetApiScopes() =>
            new ApiScope[]
            {
                new ApiScope("MyFinanceAPI"),
            };

        public static IEnumerable<ApiResource> GetApiResources() =>
            new ApiResource[]
            {
                new ApiResource("MyFinanceAPI")
                {
                    Scopes =
                    {
                        "MyFinanceAPI"
                    }
                },
            };

        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
    }
}
