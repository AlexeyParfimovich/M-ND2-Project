using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Infrastructure;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.BLL.Users.Dto;
using MyFinance.DAL;
using MyFinance.DAL.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyFinance.API.Infrastructure
{
    public class UserHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<UserHandlerMiddleware> _logger; 

        public UserHandlerMiddleware(
            RequestDelegate next, 
            ILogger<UserHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context, IFinanceDbContext database)
        {
            //var userClaims = context.User.Claims;

            if (context.User.Identity.IsAuthenticated)
            {
                var dto = new FetchUserDto()
                {
                    UserName = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value,
                    Email = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value
                };

                var entity = await database.Context.Users.FirstOrDefaultAsync(x => x.UserName == dto.UserName && x.Email == dto.Email);

                if (entity is null)
                {
                    using var transaction = await database.Context.Database.BeginTransactionAsync();

                    try
                    {
                        var entry = await database.Context.Users.AddAsync(ContractsMapper.Map<FetchUserDto, UserEntity>(dto));

                        await database.Context.SaveChangesAsync();

                        await transaction.CommitAsync();

                        context.Items["UserId"] = entry.Entity.Id;

                        _logger.LogInformation($"New user created: {entry.Entity.UserName}, {entry.Entity.Email}");
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();

                        throw new DataSaveChangesException($"Error saving new User", ex);
                    }
                }
                else
                {
                    context.Items["UserId"] = entity.Id;
                }

            }
            
            await _next(context);
        }
    }
}
