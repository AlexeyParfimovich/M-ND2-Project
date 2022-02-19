using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyFinance.IdentityServer.Database;
using MyFinance.IdentityServer.Infrastructure;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace MyFinance.IdentityServer
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IHostEnvironment _environment;

        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IEmailService, EmailService>();

            services.AddDbContext<AuthDbContext>(config =>
            {
                config
                //.UseInMemoryDatabase("AuthDb");
                .UseSqlServer(_configuration.GetConnectionString(nameof(AuthDbContext)));
            })
            .AddIdentity<IdentityUser, IdentityRole>(config =>
            {
                config.Password.RequireDigit = false;
                config.Password.RequireLowercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(config => 
            {
                config.LoginPath = "/Auth/Login";
                config.LogoutPath = "/Auth/Logout";
                config.Cookie.Name = "IdentifyServer.Cookies";
            });

            //Create signing credential certificate file
            //var _filePath = Path.Combine(_environment.ContentRootPath, "ISCredential_certificate.pfx");
            //var _certificate = new X509Certificate2(_filePath, "p@ssw0rd");

            services.AddIdentityServer()
                .AddAspNetIdentity<IdentityUser>()
                .AddInMemoryClients(ISConfig.GetClients())
                .AddInMemoryApiScopes(ISConfig.GetApiScopes())
                .AddInMemoryApiResources(ISConfig.GetApiResources())
                .AddInMemoryIdentityResources(ISConfig.GetIdentityResources())
                .AddProfileService<ProfileService>()
                //.AddSigningCredential(_certificate);
                .AddDeveloperSigningCredential();

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
