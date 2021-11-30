using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.DAL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDatabaseContext(this IServiceCollection services)
        {
            services.AddDbContext<FinanceDbContext>();
            services.AddScoped<IFinanceDbContext, FinanceDbContext>();

            return services;
        }
    }
}
