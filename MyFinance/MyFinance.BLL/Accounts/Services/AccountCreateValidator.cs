using Microsoft.EntityFrameworkCore;
using MyFinance.BLL.Abstracts;
using MyFinance.BLL.Accounts.Dto;
using MyFinance.BLL.Interfaces;
using MyFinance.DAL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFinance.BLL.Accounts.Services
{
    public class AccountCreateValidator : BaseService, IValidator<CreateAccountDto>
    {
        public AccountCreateValidator(IFinanceDbContext database) : base(database)
        {
        }

        public async Task<Task> Validate(CreateAccountDto dto)
        {
            if (dto is null)
            {
                throw new NullReferenceException();
            }

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ArgumentNullException(dto.Name);
            }

            /*
             * Implement BudgetId validation
             */
            var budget = await _db.Context.Budgets.AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.BudgetId);
            if (budget is null)
            {
                throw new KeyNotFoundException();
            }

            /*
             * Implement CurrencyType validation
             */
            var currency = await _db.Context.Currencies.AsNoTracking().FirstOrDefaultAsync(x => x.Type == dto.CurrencyType);
            if (currency is null)
            {
                throw new KeyNotFoundException();
            }

            return Task.CompletedTask;
        }
    }
}
