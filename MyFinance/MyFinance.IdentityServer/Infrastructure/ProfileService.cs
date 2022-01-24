using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyFinance.IdentityServer.Infrastructure
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var claim = context.Subject.Claims.FirstOrDefault(c => c.Type == "sub");

            if (claim is not null)
            {
                var user = _userManager.FindByIdAsync(claim.Value);

                context.IssuedClaims.AddRange(new Claim[] 
                { 
                    new Claim(ClaimTypes.Name, user.Result.UserName),
                    new Claim(ClaimTypes.Email, user.Result.Email),
                });
            }
            else
            {
                context.IssuedClaims.AddRange(context.Subject.Claims);
            }

            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;

            return Task.CompletedTask;
        }
    }
}
