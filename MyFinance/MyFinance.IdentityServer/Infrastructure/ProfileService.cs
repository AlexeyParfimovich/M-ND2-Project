using IdentityServer4.Models;
using IdentityServer4.Services;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyFinance.IdentityServer.Infrastructure
{
    public class ProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Email, "test@test.by"),
                new Claim(ClaimTypes.Name, "TestUser")
            };

            context.IssuedClaims.AddRange(claims);
            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;

            return Task.CompletedTask;
        }
    }
}
