using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IdentityServer4.Services;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using MyFinance.IdentityServer.Models;
using MyFinance.IdentityServer.Infrastructure;

namespace MyFinance.IdentityServer.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IIdentityServerInteractionService _interactionService;
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailService _emailService;

        public AuthController(
            IIdentityServerInteractionService interactionService,
            SignInManager<IdentityUser> signinManager,
            UserManager<IdentityUser> userManager,
            IEmailService emailService)
        {
            _interactionService = interactionService;
            _signinManager = signinManager;
            _userManager = userManager;
            _emailService = emailService;
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
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user is null)
                {
                    ModelState.AddModelError("UserName", "User not found");
                    return View(model);
                }

                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError("All", "The user's email has not been verified. Please check users email for confirmation letter");
                    return View(model);
                }

                var result = await _signinManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    await _emailService.SendTextAsync(user.Email, "MyFinance signin notification", 
                        $"User {user.UserName} was authenticated on {DateTime.Now}");

                    if (string.IsNullOrWhiteSpace(model.ReturnUrl))
                    {
                        return RedirectToAction("ViewUser", "Auth", 
                            new RegisterViewModel() 
                            { 
                                UserName = user.UserName,
                                Email = user.Email
                            });
                    }

                    return Redirect(model.ReturnUrl);
                }

                ModelState.AddModelError("All", $"Signin faults: {result}");
            }
            
            return View(model);
        }

        [Route("[action]")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user is not null)
                {
                    ModelState.AddModelError("UserName", "Specified user name already exists");
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
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Auth",
                        new { userId = user.Id, code },
                        protocol: HttpContext.Request.Scheme);

                    await _emailService.SendHtmlAsync(model.Email, "Confirm your account",
                        $"Confirm your registration by clicking on the link: <a href='{callbackUrl}'>link</a>");

                    return Content("To complete the registration, check your email and follow the link provided in the letter.");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("All", error.Description);
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return View("Error");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "User")).GetAwaiter().GetResult();
                return RedirectToAction("Login", "Auth", new { status = "Registration confirmed. Log in"});
            }

            return View("Error");
        }

        [Route("[action]")]
        public IActionResult EditUser(RegisterViewModel model)
        {
            return View(model);
        }

        [Route("[action]")]
        public IActionResult ViewUser(RegisterViewModel model)
        {
            return View(model);
        }

        [Route("[action]")]
        public async Task<IActionResult> Logout(string logoutId)
        {
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
