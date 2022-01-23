using MyFinance.Client.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace MyFinance.Client.Mvc.Controllers
{
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ClientController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("[action]")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult GoodBye()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult Logout()
        {
            var parameters = new AuthenticationProperties 
            {
                RedirectUri = "/Client/GoodBye"
            };

            return SignOut(parameters,
                OpenIdConnectDefaults.AuthenticationScheme,
                CookieAuthenticationDefaults.AuthenticationScheme);
        }

        [Authorize(Policy = "HasEmail")]
        [Route("[action]")]
        public async Task<IActionResult> Secret()
        {
            var model = new ClaimManager(HttpContext, User);

            try
            {
                var client = _httpClientFactory.CreateClient();

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", model.AccessToken);
                client.SetBearerToken(model.AccessToken);
                // Retrive secrets from MyFinance.API
                var orderSecret = await client.GetStringAsync("https://localhost:5001/api/v1/budgets/secret");
                ViewData["Message"] = orderSecret;
            }
            catch(Exception ex)
            {
                ViewData["Message"] = ex.Message;
                await RefreshToken(model.RefreshToken);
            }

            return View(model);
        }

        private async Task RefreshToken(string refreshToken)
        {
            var refreshClient = _httpClientFactory.CreateClient();
            var resultRefreshTokenAsync = await refreshClient.RequestRefreshTokenAsync(new RefreshTokenRequest
            {
                Address = "https://localhost:6001/connect/token",
                ClientId = "client_id_mvc",
                ClientSecret = "client_secret_mvc",
                RefreshToken = refreshToken,
                Scope = "openid MyFinanceAPI offline_access"
            });

            await UpdateAuthContextAsync(resultRefreshTokenAsync.AccessToken, resultRefreshTokenAsync.RefreshToken);
        }

        private async Task UpdateAuthContextAsync(string accessTokenNew, string refreshTokenNew)
        {
            var authenticate = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            authenticate.Properties.UpdateTokenValue("access_token", accessTokenNew);
            authenticate.Properties.UpdateTokenValue("refresh_token", refreshTokenNew);

            await HttpContext.SignInAsync(authenticate.Principal, authenticate.Properties);
        }
    }
}
