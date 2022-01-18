using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
                config.DefaultChallengeScheme = "oidc";
            })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddOpenIdConnect("oidc", config =>
                {
                    // The Authority to use making OpenIdConnect calls
                    config.Authority = "https://localhost:6001";

                    // The credentials to make a call
                    config.ClientId = "mvc_client_id";
                    config.ClientSecret = "mvc_client_secret";

                    // Save token to authentication cookie
                    config.SaveTokens = true;

                    // Set an authntication response type
                    config.ResponseType = "code";

                    // Enable retriving additional user claims from user info endpoint
                    //config.GetClaimsFromUserInfoEndpoint = true;

                    // Add OrderApi scope to enable access to Orders server
                    config.Scope.Add("MyFinanceAPI");
                });

            services.AddHttpClient();

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();
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
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
