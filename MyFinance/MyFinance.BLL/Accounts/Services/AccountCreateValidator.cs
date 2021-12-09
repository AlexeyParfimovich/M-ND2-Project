using Microsoft.EntityFrameworkCore;
using MyFinance.BLL.Accounts.Dto;
using MyFinance.BLL.Interfaces;
using MyFinance.DAL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFinance.BLL.Accounts.Services
{
    public class AccountCreateValidator : IValidator<CreateAccountDto>
    {
        readonly IFinanceDbContext _db;
        public AccountCreateValidator(IFinanceDbContext database)
        {
            _db = database;
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
             * Implement CurrencyType validation
             */
            var entity = await _db.Context.Currencies.AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.CurrencyId);
            if (entity is null)
            {
                throw new KeyNotFoundException();
            }

            return Task.CompletedTask;
        }
    }
}
