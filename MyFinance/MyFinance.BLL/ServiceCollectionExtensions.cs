﻿using Microsoft.Extensions.DependencyInjection;
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

            services.AddScoped<IBudgetAgregator, BudgetAgregator>();

            return services;
        }
    }
}
