using MyFinance.DAL;
using MyFinance.BLL.Accounts.Dto;
using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyFinance.BLL.Accounts.Services
{
    public class AccountUpdateValidator : IValidator<UpdateAccountDto>
    {
        readonly IFinanceDbContext _db;

        public AccountUpdateValidator(IFinanceDbContext database)
        {
            _db = database;
        }

        public async Task<Task> Validate(UpdateAccountDto dto)
        {
            if (dto is null)
            {
                throw new DataNullReferenceException();
            }

            var Account = await _db.Context.Accounts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (Account is null)
            {
                throw new ValueNotFoundException($"Specified account Id value {dto.Id} was not found");
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
