using Microsoft.Extensions.DependencyInjection;
using MyFinance.BLL.Accounts;
using MyFinance.BLL.Accounts.Dto;
using MyFinance.BLL.Accounts.Services;
using MyFinance.BLL.Budgets;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Budgets.Services;
using MyFinance.BLL.Interfaces;

namespace MyFinance.BLL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateBudgetDto>, BudgetCreateValidator>();
            services.AddScoped<IValidator<UpdateBudgetDto>, BudgetUpdateValidator>();

            services.AddScoped<ICreator<CreateBudgetDto, BudgetDto>, BudgetCreator>();
            services.AddScoped<IUpdater<UpdateBudgetDto, BudgetDto>, BudgetUpdater>();
            services.AddScoped<IFetcher<long, BudgetDto>, BudgetFetcher>();
            services.AddScoped<IRemover<long>, BudgetRemover>();

            services.AddScoped<IAgregator<long, BudgetDto, CreateBudgetDto, UpdateBudgetDto>, BudgetAgregator>();

            services.AddScoped<IValidator<CreateAccountDto>, AccountCreateValidator>();
            services.AddScoped<IValidator<UpdateAccountDto>, AccountUpdateValidator>();

            services.AddScoped<ICreator<CreateAccountDto, AccountDto>, AccountCreator>();
            services.AddScoped<IUpdater<UpdateAccountDto, AccountDto>, AccountUpdater>();
            services.AddScoped<IFetcher<long, AccountDto>, AccountFetcher>();
            services.AddScoped<IRemover<long>, AccountRemover>();

            services.AddScoped<IAgregator<long, AccountDto, CreateAccountDto, UpdateAccountDto>, AccountAgregator>();

            return services;
        }
    }
}
