using MyFinance.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IdentityServer4.Services;

namespace MyFinance.IdentityServer.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IIdentityServerInteractionService _interactionService;
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(
            IIdentityServerInteractionService interactionService,
            SignInManager<IdentityUser> signinManager,
            UserManager<IdentityUser> userManager)
        {
            _interactionService = interactionService;
            _signinManager = signinManager;
            _userManager = userManager;
        }

        [Route("[action]")]
        public IActionResult Login(string returnUrl)
        {
            //return View();

            return View(new LoginViewModel
            {
                UserName = "Admin",
                Password = "p@ssw0rd",
                ReturnUrl = returnUrl
            });
        }

        [Route("[action]")]
        public async Task<IActionResult> LogoutAsync(string logoutId)
        {
            // Signout and clean everything
            await _signinManager.SignOutAsync();

            var result = await _interactionService.GetLogoutContextAsync(logoutId);

            if (string.IsNullOrEmpty(result.PostLogoutRedirectUri))
            {
                return RedirectToAction("Login", "Auth");
            }

            return Redirect(result.PostLogoutRedirectUri);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.UserName);

            if(user is null)
            {
                ModelState.AddModelError("UserName", "User not found");
                return View(model);
            }

            var result = await _signinManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl);
            }

            // TODO: check for other bad results
            ModelState.AddModelError("UserName", $"Signin faults: {result}");
            return View(model);
        }
    }
}
