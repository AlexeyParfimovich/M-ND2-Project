using Microsoft.EntityFrameworkCore;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.DAL;
using System.Threading.Tasks;

namespace MyFinance.BLL.Budgets.Services
{
    public class BudgetUpdateValidator : IValidator<UpdateBudgetDto>
    {
        readonly IFinanceDbContext _db;

        public BudgetUpdateValidator(IFinanceDbContext database)
        {
            _db = database;
        }

        public async Task<Task> Validate(UpdateBudgetDto dto)
        {
            if (dto is null)
            {
                throw new DtoNullReferenceException();
            }

            var budget = await _db.Context.Budgets.AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (budget is null)
            {
                throw new ValueNotFoundException($"Specified budget Id value {dto.Id} was not found") ;
            }

            var currancy = await _db.Context.Currencies.AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.CurrencyId);
            if (currancy is null)
            {
                throw new ValueNotFoundException($"Specified currency type {dto.CurrencyId} was not found");
            }

            return Task.CompletedTask;
        }
    }
}
