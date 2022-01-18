using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyFinance.IdentityServer.Database;
using MyFinance.IdentityServer.Infrastructure;

namespace MyFinance.IdentityServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AuthDbContext>(config =>
            {
                config.UseInMemoryDatabase("AuthDb");
            })
            .AddIdentity<IdentityUser, IdentityRole>(config =>
            {
                config.Password.RequireDigit = false;
                config.Password.RequireLowercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<AuthDbContext>();

            services.AddIdentityServer(options =>
            {
                // Setup custom IS login endpoint Url
                options.UserInteraction.LoginUrl = "/Auth/Login";
            })
                .AddAspNetIdentity<IdentityUser>()
                .AddInMemoryClients(ISConfig.GetClients())
                .AddInMemoryApiScopes(ISConfig.GetApiScopes())
                .AddInMemoryApiResources(ISConfig.GetApiResources())
                .AddInMemoryIdentityResources(ISConfig.GetIdentityResources())
                .AddProfileService<ProfileService>()
                .AddDeveloperSigningCredential();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseIdentityServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
