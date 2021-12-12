using MyFinance.API.Models;
using MyFinance.BLL.Accounts.Dto;

namespace MyFinance.API.Controllers
{
    public static class AccountModelMapper
    {
        public static CreateAccountDto MapToDtoCreate(CreateAccountModel model)
        {
            return new CreateAccountDto
            {
                Name = model.Name,
                BudgetId = model.BudgetId,
                CurrencyId = model.CurrencyId,
            };
        }

        public static UpdateAccountDto MapToDtoUpdate(UpdateAccountModel model)
        {
            return new UpdateAccountDto
            {
                Id = model.Id,
                Name = model.Name,
                BudgetId = model.BudgetId,
                CurrencyId = model.CurrencyId,
            };
        }

        public static AccountModel MapToModel(AccountDto dto)
        {
            return new AccountModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Balance = dto.Balance,
                BudgetId = dto.BudgetId,
                CurrencyId = dto.CurrencyId,
                LastTransaction = dto.LastTransaction,
            };
        }
    }
}
