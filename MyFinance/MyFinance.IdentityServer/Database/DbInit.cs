using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace MyFinance.IdentityServer.Database
{
    /// <summary>
    /// Create default admin user 
    /// </summary>
    public static class DbInit
    {
        public static void Init(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = new IdentityUser
            {
                UserName = "Admin",
                Email = "admin@test.by"
            };

            var result = userManager.CreateAsync(user, "p@ssw0rd").GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Administrator")).GetAwaiter().GetResult();
            }
        }
    }
}
