using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyFinance.API.Infrastructure;
using Serilog;
using System;
using System.Collections.Generic;

namespace MyFinance.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            DAL.ServiceCollectionExtensions.RegisterDatabaseContext(services);
            BLL.ServiceCollectionExtensions.RegisterBusinessServices(services);

            services.AddControllers().AddNewtonsoftJson();

            //services.AddMemoryCache();
            services.AddStackExchangeRedisCache(options => 
            {
                options.Configuration = Configuration.GetConnectionString("RedisServer");
            });

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
                                    // If scopes are not specified, they are not requested during authentication
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
                    options.Authority = "https://localhost:6001"; // IdentityServer host
                    options.RequireHttpsMetadata = false;
                });

            services.AddAuthorization();

            services.AddCors(options =>
                {   // allow everything
                    options.AddPolicy("DefaultPolicy", builder =>
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                });
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
                    options.OAuthClientId("client_id_swagger");
                    options.OAuthClientSecret("client_secret_swagger");
                });
            }

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseCors("DefaultPolicy"); // Enable cross-domain requests based on the policy configured above.

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<UserHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
