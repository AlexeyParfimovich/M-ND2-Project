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
                new Client()
                {
                    ClientId = "client_id_swagger",
                    ClientSecrets = { new Secret("client_secret_swagger".ToSha256()) },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedCorsOrigins = { "https://localhost:5001" },
                    AllowedScopes =
                    {
                        "MyFinanceSwagger",
                        IdentityServerConstants.StandardScopes.OpenId, // "openid"
                        IdentityServerConstants.StandardScopes.Profile // "profile"
                    }
                },

                new Client()
                {
                    ClientId = "client_id_mvc",
                    ClientSecrets = { new Secret("client_secret_mvc".ToSha256()) },

                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes =
                    {
                        "MyFinanceMVC",
                        "MyFinanceAPI",
                        IdentityServerConstants.StandardScopes.OpenId, // "openid"
                        IdentityServerConstants.StandardScopes.Profile // "profile"
                    },

                    RedirectUris = { "https://localhost:9001/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:9001/signout-callback-oidc" },

                    RequireConsent = false, //Specifies whether a consent page is required
                    //AlwaysIncludeUserClaimsInIdToken = true, //Set user claims always be added to the id token
                    //AccessTokenLifetime = 10, // Lifetime of access token in seconds (defaults to 3600 seconds)
                    AllowOfflineAccess = true, // Enable Refresh Token be issued
                },

                new Client()
                {
                    ClientId = "client_id_js",

                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedCorsOrigins = { "https://localhost:10001" },
                    AllowedScopes =
                    {
                        "MyFinanceAPI",
                        IdentityServerConstants.StandardScopes.OpenId, // "openid"
                        IdentityServerConstants.StandardScopes.Profile // "profile"
                    },

                    RedirectUris = 
                    { 
                        "https://localhost:10001/callback.html",
                        "https://localhost:10001/refresh.html",
                    },
                    PostLogoutRedirectUris = { "https://localhost:10001/index.html" },

                    RequireClientSecret = false,
                    RequireConsent = false,
                    RequirePkce = true,

                    //AccessTokenLifetime = 10, // Lifetime of access token in seconds (defaults to 3600 seconds)
                    AllowOfflineAccess = true,
                },

            };

        internal static IEnumerable<ApiScope> GetApiScopes() =>
            new ApiScope[]
            {
                new ApiScope("MyFinanceAPI"),
                new ApiScope("MyFinanceSwagger"),
                //new ApiScope("MyFinanceClientJS"),
                new ApiScope("MyFinanceClientMVC"),
            };

        public static IEnumerable<ApiResource> GetApiResources() =>
            new ApiResource[]
            {
                new ApiResource("MyFinanceAPI")
                {
                    Scopes =
                    {
                        "MyFinanceAPI",
                        "MyFinanceSwagger",
                        "MyFinanceClientMVC",
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
