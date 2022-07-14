using MyFinance.DAL;
using MyFinance.BLL.Cards.Dto;
using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyFinance.BLL.Cards.Services
{
    public class CardUpdateValidator : IValidator<UpdateCardDto>
    {
        readonly IFinanceDbContext _db;

        public CardUpdateValidator(IFinanceDbContext database)
        {
            _db = database;
        }

        public async Task<Task> Validate(UpdateCardDto dto)
        {
            if (dto is null)
                throw new DataNullReferenceException();

            if (await _db.Context.Cards.AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.Id) is null)
                throw new ValueNotFoundException($"Specified Card Id value {dto.Id} was not found");

            if (await _db.Context.Budgets.AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.BudgetId) is null)
                throw new ValueNotFoundException($"Specified budget Id value {dto.BudgetId} was not found");

            if (await _db.Context.Accounts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.AccountId) is null)
                throw new ValueNotFoundException($"Specified account Id value {dto.AccountId} was not found");

            return Task.CompletedTask;
        }
    }
}
