using MyFinance.BLL.Accounts.Dto;
using MyFinance.BLL.Interfaces;
using MyFinance.DAL.Entities;

namespace MyFinance.BLL.Accounts.Services
{
    public class AccountUpdateMapper : IDtoPartialMapper<AccountEntity, AccountDto, UpdateAccountDto>
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

        public AccountEntity DtoToEntity(UpdateAccountDto dto)
        {
            return new AccountEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                CurrencyId = dto.CurrencyId,
            };
        }
    }
}
