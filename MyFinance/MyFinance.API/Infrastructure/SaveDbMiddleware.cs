using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyFinance.DAL;
using MyFinance.DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.API.Infrastructure
{
    public class SaveDbMiddleware
    {
        private readonly RequestDelegate _next;

        public SaveDbMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IFinanceDbContext database)
        {
            await _next(context);

            // Not used
            var entities = database.Context.ChangeTracker.Entries()
            .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            if(entities.Any())
            {
                //await database.Context.SaveChangesAsync();
            }
        }
    }
}
