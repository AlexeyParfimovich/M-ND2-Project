using MyFinance.BLL.Accounts.Dto;
using MyFinance.DAL.Entities;

namespace MyFinance.BLL.Accounts.Services
{
    public static class AccountDtoMapper
    {
        public static AccountEntity MapToEntityCreate(CreateAccountDto dto)
        {
            return new AccountEntity
            {
                Name = dto.Name,
                BudgetId = dto.BudgetId,
                CurrencyType = dto.CurrencyType,
            };
        }

        public static AccountEntity MapToEntityUpdate(UpdateAccountDto dto)
        {
            return new AccountEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                BudgetId = dto.BudgetId,
                CurrencyType = dto.CurrencyType,
            };
        }

        public static AccountDto MapToDto(AccountEntity entity)
        {
            return new AccountDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Balance = entity.Balance,
                BudgetId = entity.BudgetId,
                CurrencyType = entity.CurrencyType,
                LastTransaction = entity.LastTransaction
            };
        }
    }
}
