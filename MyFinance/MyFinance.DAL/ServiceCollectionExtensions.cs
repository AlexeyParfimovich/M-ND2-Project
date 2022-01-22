using Microsoft.Extensions.DependencyInjection;

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
