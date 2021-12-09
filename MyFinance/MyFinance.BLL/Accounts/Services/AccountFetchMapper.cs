using MyFinance.BLL.Accounts.Dto;
using MyFinance.BLL.Interfaces;
using MyFinance.DAL.Entities;

namespace MyFinance.BLL.Accounts.Services
{
    public class AccountFetchMapper : IDtoMapper<AccountEntity, AccountDto>
    {
        public AccountDto EntityToDto(AccountEntity entity)
        {
            return new AccountDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Balance = entity.Balance,
                CurrencyId = entity.CurrencyId,
            };
        }
    }
}
