using MyFinance.DAL.Entities;
using MyFinance.BLL.Accounts.Dto;
using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Accounts.Services
{
    public class AccountCreateMapper : IDtoPartialMapper<AccountEntity, AccountDto, CreateAccountDto>
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

        public AccountEntity DtoToEntity(CreateAccountDto dto)
        {
            return new AccountEntity
            {
                Name = dto.Name,
                CurrencyId = dto.CurrencyId,
            };
        }
    }
}
