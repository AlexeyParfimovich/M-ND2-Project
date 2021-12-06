using Microsoft.EntityFrameworkCore;
using MyFinance.BLL.Abstracts;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Interfaces;
using MyFinance.DAL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFinance.BLL.Budgets.Services
{
    public class BudgetUpdateValidator : BaseService, IValidator<UpdateBudgetDto>
    {
        public BudgetUpdateValidator(IFinanceDbContext database) : base(database)
        {
        }

        public async Task<Task> Validate(UpdateBudgetDto dto)
        {
            if (dto is null)
            {
                throw new NullReferenceException();
            }

            /*
            * Implement Id validation
            */
            var budget = await _db.Context.Budgets.AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.Id);
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
