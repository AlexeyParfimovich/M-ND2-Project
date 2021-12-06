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
    public class BudgetCreateValidator : BaseService, IValidator<CreateBudgetDto>
    {
        public BudgetCreateValidator(IFinanceDbContext database): base(database)
        {
        }

        public async Task<Task> Validate(CreateBudgetDto dto)
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
             * Implement CurrencyType validation
             */
            var entity = await _db.Context.Currencies.AsNoTracking().FirstOrDefaultAsync(x => x.Type == dto.CurrencyType);
            if (entity is null)
            {
                throw new KeyNotFoundException();
            }


            return Task.CompletedTask;
        }
    }
}
