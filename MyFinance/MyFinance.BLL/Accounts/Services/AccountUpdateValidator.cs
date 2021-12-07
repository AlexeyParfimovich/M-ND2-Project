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
    public class AccountUpdateValidator : BaseService, IValidator<UpdateAccountDto>
    {
        public AccountUpdateValidator(IFinanceDbContext database) : base(database)
        {
        }

        public async Task<Task> Validate(UpdateAccountDto dto)
        {
            if (dto is null)
            {
                throw new NullReferenceException();
            }

            /*
            * Implement Id validation
            */
            var account = await _db.Context.Accounts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (account is null)
            {
                throw new KeyNotFoundException();
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
             * TODO: Implement CurrencyType validation
             */
            var currancy = await _db.Context.Currencies.AsNoTracking().FirstOrDefaultAsync(x => x.Type == dto.CurrencyType);
            if (currancy is null)
            {
                throw new KeyNotFoundException();
            }

            return Task.CompletedTask;
        }
    }
}
