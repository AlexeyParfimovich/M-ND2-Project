using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

namespace MyFinance.Client.Mvc
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(config =>
            {
                // Set authentication scheme to "Cookie"
                config.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                // Set challenge scheme to OpenId connect - "oidc"
                config.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, config =>
                {
                    // Setup new token validation interval (defaults to - 300 seconds)
                    //config.TokenValidationParameters = new TokenValidationParameters
                    //{
                    //    ClockSkew = System.TimeSpan.FromSeconds(10)
                    //};

                    // The Authority to use making OpenIdConnect calls
                    config.Authority = "https://localhost:6001";

                    // The credentials to make a call
                    config.ClientId = "client_id_mvc";
                    config.ClientSecret = "client_secret_mvc";

                    // Save token to authentication cookie
                    config.SaveTokens = true;

                    // Set an authntication response type
                    config.ResponseType = "code";

                    // Add OrderApi scope to enable access to Orders server
                    config.Scope.Add("MyFinanceMVC");
                    config.Scope.Add("MyFinanceAPI");
                    // Enable Refresh Token be issued
                    config.Scope.Add("offline_access");

                    // Enable retriving additional user claims from user info endpoint
                    config.GetClaimsFromUserInfoEndpoint = true;

                    // Map all values form user info as claims!
                    //config.ClaimActions.MapAll();
                    config.ClaimActions.MapJsonKey(ClaimTypes.Email, ClaimTypes.Email);
                    config.ClaimActions.MapJsonKey(ClaimTypes.Name, ClaimTypes.Name);
                });

            services.AddAuthorization(config => 
            {
                config.AddPolicy("HasEmail", builder => 
                {
                    builder.RequireClaim(ClaimTypes.Email);
                });
            });

            services.AddHttpClient();

            services.AddControllersWithViews();
                //.AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints
                //.MapDefaultControllerRoute()
                .MapControllerRoute(name: "default",
                    pattern: "{controller=Client}/{action=Index}/{id?}",
                    defaults: new { controller = "Client", action = "Index" });
            });
        }


    }
}
