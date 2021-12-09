using Microsoft.EntityFrameworkCore;
using MyFinance.BLL.Accounts.Dto;
using MyFinance.BLL.Interfaces;
using MyFinance.DAL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
                throw new NullReferenceException();
            }

            /*
            * Implement Id validation
            */
            var Account = await _db.Context.Accounts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (Account is null)
            {
                throw new KeyNotFoundException();
            }

            /*
             * TODO: Implement CurrencyType validation
             */
            var currancy = await _db.Context.Currencies.AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.CurrencyId);
            if (currancy is null)
            {
                throw new KeyNotFoundException();
            }

            return Task.CompletedTask;
        }
    }
}
