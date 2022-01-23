using MyFinance.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IdentityServer4.Services;
using System.Security.Claims;

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
            return View();
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

        [Route("[action]")]
        public IActionResult Register(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user is not null)
            {
                ModelState.AddModelError("UserName", "Specified user name already exists");
                return View(model);
            }

            user = await _userManager.FindByEmailAsync(model.Email);

            if (user is not null)
            {
                ModelState.AddModelError("UserName", "Specified email already exists");
                return View(model);
            }

            user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = _userManager.CreateAsync(user, model.Password).GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "User")).GetAwaiter().GetResult();

                return Redirect(model.ReturnUrl);
            }

            // TODO: check for other bad results
            ModelState.AddModelError("UserName", $"Registration faults: {result}");
            return View(model);
        }

        [Route("[action]")]
        public async Task<IActionResult> Logout(string logoutId)
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
    }
}
