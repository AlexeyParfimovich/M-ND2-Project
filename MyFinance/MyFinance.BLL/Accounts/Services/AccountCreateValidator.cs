using MyFinance.DAL;
using MyFinance.BLL.Accounts.Dto;
using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Interfaces;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
                throw new DataNullReferenceException();

            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ValueNotSpecifiedException($"Name property not specified");

            if (await _db.Context.Budgets.AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.BudgetId) is null)
                throw new ValueNotFoundException($"Specified budget {dto.BudgetId} was not found");

            if (await _db.Context.Currencies.AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.CurrencyId) is null)
                throw new ValueNotFoundException($"Specified currency type {dto.CurrencyId} was not found");

            return Task.CompletedTask;
        }
    }
}
