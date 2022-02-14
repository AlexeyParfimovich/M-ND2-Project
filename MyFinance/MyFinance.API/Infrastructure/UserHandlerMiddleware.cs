using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Infrastructure;
using MyFinance.BLL.Users.Dto;
using MyFinance.DAL;
using MyFinance.DAL.Entities;
using System;
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
            if (context.User.Identity.IsAuthenticated)
            {
                var dto = new FetchUserDto()
                {
                    UserName = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value,
                    Email = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value
                };

                var userId = await GetUser(database, dto);

                if (userId == Guid.Empty)
                {
                    context.Items["UserId"] = await AddUser(database, dto);
                    _logger.LogInformation($"New user created: {dto.UserName}, {dto.Email}");
                }
                else
                {
                    context.Items["UserId"] = userId;
                }
            }

            await _next(context);
        }

        private static async Task<Guid> AddUser(IFinanceDbContext database, FetchUserDto user)
        {
            using var transaction = await database.Context.Database.BeginTransactionAsync();

            try
            {
                var entry = await database.Context.Users.AddAsync(ContractsMapper.Map<FetchUserDto, UserEntity>(user));

                await database.Context.SaveChangesAsync();

                await transaction.CommitAsync();

                return entry.Entity.Id;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                throw new DataSaveChangesException($"Error adding new User", ex);
            }
        }

        private static async Task<Guid> GetUser(IFinanceDbContext database, FetchUserDto user)
        {
            var entity = await database.Context.Users
                .FirstOrDefaultAsync(x => x.UserName == user.UserName && x.Email == user.Email);

            return entity is null ? Guid.Empty : entity.Id;
        }
    }
}
