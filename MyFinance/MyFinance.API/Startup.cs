using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyFinance.API.Infrastructure;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;

namespace MyFinance.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services
            //    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, config =>
            //    {
            //        // Setup new token validation interval (defaults to - 300 seconds)
            //        config.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ClockSkew = System.TimeSpan.FromSeconds(10)
            //        };

            //        // The Authority to use making OpenIdConnect calls
            //        config.Authority = "https://localhost:6001";
            //        config.Audience = "MyFinanceAPI";
            //    });

            DAL.ServiceCollectionExtensions.RegisterDatabaseContext(services);
            BLL.ServiceCollectionExtensions.RegisterBusinessServices(services);

            services.AddControllers().AddNewtonsoftJson();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Description = "Swager demo API v1",
                    Title = "MyFinance.API", 
                    Version = "v1" 
                });

                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
                    { 
                        Type = SecuritySchemeType.OAuth2,
                        Flows = new OpenApiOAuthFlows
                        {
                            Password = new OpenApiOAuthFlow
                            {
                                TokenUrl = new Uri("https://localhost:6001/connect/token"),
                                Scopes = new Dictionary<string, string>()
                                {
                                    // If scopes are not specified, then they are not requested during authentication in swager
                                    //{"MyFinanceAPI","MyFinance application REST API"}
                                }
                            }
                        }
                    });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>() // must be empty based on OpenSecurityRequirements
                    }
                });

            });

            services.AddAuthentication(options => 
                {
                    // Use "Bearer"
                    options.DefaultScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                })
                .AddIdentityServerAuthentication(options => 
                {
                    options.ApiName = "MyFinanceAPI";
                    options.Authority = "https://localhost:6001";
                    options.RequireHttpsMetadata = false;
                });

            services.AddAuthorization();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMiddleware<SaveDbMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "MyFinance.API v1");
                    //options.DocumentTitle = "Title";
                    //options.RoutePrefix = "Prefix";
                    //options.DocExpansion(docExpansion: DocExpansion.List);
                    options.OAuthClientId("client_id_swagger");
                    options.OAuthClientSecret("client_secret_swagger");
                });
            }

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
