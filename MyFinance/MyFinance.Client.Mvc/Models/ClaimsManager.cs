using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace MyFinance.Client.Mvc.Models
{
    /// <summary>
    /// Claims manager
    /// </summary>
    public class ClaimManager
    {
        public ClaimManager(HttpContext context, ClaimsPrincipal user)
        {
            if (context == null) 
                throw new ArgumentNullException(nameof(context));
            Items = new List<ClaimViewer>();

            var claims = user.Claims.ToList();
            var idToken = context.GetTokenAsync("id_token").GetAwaiter().GetResult();
            var accessToken = context.GetTokenAsync("access_token").GetAwaiter().GetResult();
            var refreshToken = context.GetTokenAsync("refresh_token").GetAwaiter().GetResult();

            AddTokenInfo("Refresh Token", refreshToken, true);
            AddTokenInfo("Identity Token", idToken);
            AddTokenInfo("Access Token", accessToken);
            AddTokenInfo("User Claims", claims);
        }

        public List<ClaimViewer> Items { get; }

        public string AccessToken
        {
            get
            {
                if (Items == null || Items.Count == 0)
                {
                    throw new InvalidOperationException("Not tokens found");
                }
                var token = Items.SingleOrDefault(x => x.Name == "Access Token");
                if (token == null)
                {
                    throw new InvalidOperationException("Not tokens found");
                }

                return token.Token;
            }
        }

        public string RefreshToken
        {
            get
            {
                if (Items == null || Items.Count == 0)
                {
                    throw new InvalidOperationException("Not tokens found");
                }
                var token = Items.SingleOrDefault(x => x.Name == "Refresh Token");
                if (token == null)
                {
                    throw new InvalidOperationException("Not tokens found");
                }

                return token.Token;
            }
        }

        private void AddTokenInfo(string tokenName, string token, bool skipParsing = false)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return;
            }
            Items.Add(new ClaimViewer(tokenName, token, skipParsing));
        }

        private void AddTokenInfo(string tokenName, IEnumerable<Claim> claims)
        {
            Items.Add(new ClaimViewer(tokenName, claims));
        }
    }
}