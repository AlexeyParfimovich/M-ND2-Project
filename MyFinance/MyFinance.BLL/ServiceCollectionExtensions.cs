using Microsoft.Extensions.DependencyInjection;
using MyFinance.BLL.Accounts;
using MyFinance.BLL.Accounts.Dto;
using MyFinance.BLL.Accounts.Services;
using MyFinance.BLL.Budgets;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Budgets.Services;
using MyFinance.BLL.Cards;
using MyFinance.BLL.Cards.Dto;
using MyFinance.BLL.Cards.Services;
using MyFinance.BLL.Currencies;
using MyFinance.BLL.Currencies.Dto;
using MyFinance.BLL.Currencies.Services;
using MyFinance.BLL.Users;
using MyFinance.BLL.Users.Dto;
using MyFinance.BLL.Users.Services;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.DAL.Entities;

namespace MyFinance.BLL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
        {
            // Add User services
            services.AddScoped<IValidator<CreateUserDto>, UserCreateValidator>();
            services.AddScoped<IValidator<UpdateUserDto>, UserUpdateValidator>();

            services.AddScoped<ICreator<UserEntity, FetchUserDto, CreateUserDto>, UserCreator>();
            services.AddScoped<IUpdater<UserEntity, FetchUserDto, UpdateUserDto>, UserUpdater>();
            services.AddScoped<IFetcher<UserEntity, FetchUserDto>, UserFetcher>();
            services.AddScoped<IRemover<UserEntity>, UserRemover>();

            services.AddScoped<IAgregator<UserEntity, FetchUserDto, CreateUserDto, UpdateUserDto>, UserAgregator>();

            // Add Budget services
            services.AddScoped<IValidator<CreateBudgetDto>, BudgetCreateValidator>();
            services.AddScoped<IValidator<UpdateBudgetDto>, BudgetUpdateValidator>();

            services.AddScoped<ICreator<BudgetEntity, FetchBudgetDto, CreateBudgetDto>, BudgetCreator>();
            services.AddScoped<IUpdater<BudgetEntity, FetchBudgetDto, UpdateBudgetDto>, BudgetUpdater>();
            services.AddScoped<IFetcher<BudgetEntity, FetchBudgetDto>, BudgetFetcher>();
            services.AddScoped<IRemover<BudgetEntity>, BudgetRemover>();

            services.AddScoped<IAgregator<BudgetEntity, FetchBudgetDto, CreateBudgetDto, UpdateBudgetDto>, BudgetAgregator>();

            /*
            // add Account services
            services.AddScoped<IValidator<CreateAccountDto>, AccountCreateValidator>();
            services.AddScoped<IValidator<UpdateAccountDto>, AccountUpdateValidator>();

            services.AddScoped<ICreator<AccountEntity, AccountDto, CreateAccountDto>, AccountCreator>();
            services.AddScoped<IUpdater<AccountEntity, AccountDto, UpdateAccountDto>, AccountUpdater>();
            services.AddScoped<IFetcher<AccountEntity, long, AccountDto>, AccountFetcher>();
            services.AddScoped<IRemover<AccountEntity, long>, AccountRemover>();

            services.AddScoped<IAgregator<AccountEntity, long, AccountDto, CreateAccountDto, UpdateAccountDto>, AccountAgregator>();

            // add Card services
            services.AddScoped<IValidator<CreateCardDto>, CardCreateValidator>();
            services.AddScoped<IValidator<UpdateCardDto>, CardUpdateValidator>();

            services.AddScoped<ICreator<CardEntity, CardDto, CreateCardDto>, CardCreator>();
            services.AddScoped<IUpdater<CardEntity, CardDto, UpdateCardDto>, CardUpdater>();
            services.AddScoped<IFetcher<CardEntity, string, CardDto>, CardFetcher>();
            services.AddScoped<IRemover<CardEntity, string>, CardRemover>();

            services.AddScoped<IAgregator<CardEntity, string, CardDto, CreateCardDto, UpdateCardDto>, CardAgregator>();

            // add Currency services
            services.AddScoped<IValidator<CreateCurrencyDto>, CurrencyCreateValidator>();
            services.AddScoped<IValidator<UpdateCurrencyDto>, CurrencyUpdateValidator>();

            services.AddScoped<ICreator<CurrencyEntity, CurrencyDto, CreateCurrencyDto>, CurrencyCreator>();
            services.AddScoped<IUpdater<CurrencyEntity, CurrencyDto, UpdateCurrencyDto>, CurrencyUpdater>();
            services.AddScoped<IFetcher<CurrencyEntity, string, CurrencyDto>, CurrencyFetcher>();
            services.AddScoped<IRemover<CurrencyEntity, string>, CurrencyRemover>();

            services.AddScoped<IAgregator<CurrencyEntity, string, CurrencyDto, CreateCurrencyDto, UpdateCurrencyDto>, CurrencyAgregator>();
            */

            return services;
        }
    }
}
