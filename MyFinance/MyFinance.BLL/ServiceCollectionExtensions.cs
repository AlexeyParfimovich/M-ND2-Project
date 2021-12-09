using Microsoft.Extensions.DependencyInjection;
using MyFinance.BLL.Accounts;
using MyFinance.BLL.Accounts.Dto;
using MyFinance.BLL.Accounts.Services;
using MyFinance.BLL.Budgets;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Budgets.Services;
using MyFinance.BLL.Interfaces;
using MyFinance.DAL.Entities;

namespace MyFinance.BLL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
        {
            // Add Budget services
            services.AddScoped<IValidator<CreateBudgetDto>, BudgetCreateValidator>();
            services.AddScoped<IValidator<UpdateBudgetDto>, BudgetUpdateValidator>();
            services.AddScoped<IDtoMapper<BudgetEntity, BudgetDto>, BudgetFetchMapper>();
            services.AddScoped<IDtoPartialMapper<BudgetEntity, BudgetDto, CreateBudgetDto>, BudgetCreateMapper>();
            services.AddScoped<IDtoPartialMapper<BudgetEntity, BudgetDto, UpdateBudgetDto>, BudgetUpdateMapper>();

            services.AddScoped<ICreator<BudgetEntity, BudgetDto, CreateBudgetDto>, BudgetCreator>();
            services.AddScoped<IUpdater<BudgetEntity, BudgetDto, UpdateBudgetDto>, BudgetUpdater>();
            services.AddScoped<IFetcher<BudgetEntity, long, BudgetDto>, BudgetFetcher>();
            services.AddScoped<IRemover<BudgetEntity, long>, BudgetRemover>();

            services.AddScoped<IAgregator<BudgetEntity, long, BudgetDto, CreateBudgetDto, UpdateBudgetDto>, BudgetAgregator>();

            // add Account services
            services.AddScoped<IValidator<CreateAccountDto>, AccountCreateValidator>();
            services.AddScoped<IValidator<UpdateAccountDto>, AccountUpdateValidator>();
            services.AddScoped<IDtoMapper<AccountEntity, AccountDto>, AccountFetchMapper>();
            services.AddScoped<IDtoPartialMapper<AccountEntity, AccountDto, CreateAccountDto>, AccountCreateMapper>();
            services.AddScoped<IDtoPartialMapper<AccountEntity, AccountDto, UpdateAccountDto>, AccountUpdateMapper>();

            services.AddScoped<ICreator<AccountEntity, AccountDto, CreateAccountDto>, AccountCreator>();
            services.AddScoped<IUpdater<AccountEntity, AccountDto, UpdateAccountDto>, AccountUpdater>();
            services.AddScoped<IFetcher<AccountEntity, long, AccountDto>, AccountFetcher>();
            services.AddScoped<IRemover<AccountEntity, long>, AccountRemover>();

            services.AddScoped<IAgregator<AccountEntity, long, AccountDto, CreateAccountDto, UpdateAccountDto>, AccountAgregator>();



            return services;
        }
    }
}
