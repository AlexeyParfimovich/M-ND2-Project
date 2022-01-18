using MyFinance.Client.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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

        [Authorize]
        [Route("[action]")]
        public async Task<IActionResult> Secret()
        {
            var model = new ClaimManager(HttpContext, User);

            try
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", model.AccessToken);

                // Retrive secrets from MyFinance.API
                var orderSecert = await client.GetStringAsync("https://localhost:5001/api/v1/budgets/secret");
                ViewData["Message"] = orderSecert;
            }
            catch(Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
            
            try
            {
                //ViewBag.Message = await GetSecretAsync(model);
                //return View(model);
            }
            catch
            {
                //await RefreshToken(model.RefreshToken);
                //var model2 = new ClaimManager(HttpContext, User);
                //ViewBag.Message = await GetSecretAsync(model2);
            }
            return View(model);
        }

        //private async Task<string> GetSecretAsync(ClaimManager model)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    client.SetBearerToken(model.AccessToken);
        //    return await client.GetStringAsync("https://localhost:5001/site/secret");
        //}

        //private async Task RefreshToken(string refreshToken)
        //{
        //    var refreshClient = _httpClientFactory.CreateClient();
        //    var resultRefreshTokenAsync = await refreshClient.RequestRefreshTokenAsync(new RefreshTokenRequest
        //    {
        //        Address = "https://localhost:10001/connect/token",
        //        ClientId = "client_id_mvc",
        //        ClientSecret = "client_secret_mvc",
        //        RefreshToken = refreshToken,
        //        Scope = "openid OrdersAPI offline_access"
        //    });

        //    await UpdateAuthContextAsync(resultRefreshTokenAsync.AccessToken, resultRefreshTokenAsync.RefreshToken);
        //}

        //private async Task UpdateAuthContextAsync(string accessTokenNew, string refreshTokenNew)
        //{
        //    var authenticate = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        //    authenticate.Properties.UpdateTokenValue("access_token", accessTokenNew);
        //    authenticate.Properties.UpdateTokenValue("refresh_token", refreshTokenNew);

        //    await HttpContext.SignInAsync(authenticate.Principal, authenticate.Properties);
        //}
    }
}
