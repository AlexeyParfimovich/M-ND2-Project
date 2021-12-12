using MyFinance.DAL;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyFinance.BLL.Budgets.Services
{
    public class BudgetCreateValidator : IValidator<CreateBudgetDto>
    {
        readonly IFinanceDbContext _db;
        public BudgetCreateValidator(IFinanceDbContext database)
        {
            _db = database;
        }

        public async Task<Task> Validate(CreateBudgetDto dto)
        {
            if (dto is null)
            {
                throw new DataNullReferenceException();
            }

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ValueNotSpecifiedException($"Name property not specified");
            }

            var entity = await _db.Context.Currencies.AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.CurrencyId);
            if (entity is null)
            {
                throw new ValueNotFoundException($"Specified currency type {dto.CurrencyId} was not found");
            }

            return Task.CompletedTask;
        }
    }
}
