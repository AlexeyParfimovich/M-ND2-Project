using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Abstracts;
using MyFinance.BLL.Accounts.Dto;
using MyFinance.BLL.Interfaces;

namespace MyFinance.BLL.Accounts.Services
{
    public class AccountCreator : BaseCreateService<AccountEntity, AccountDto, CreateAccountDto>, ICreator<AccountEntity, AccountDto, CreateAccountDto>
    {
        public AccountCreator(
            IFinanceDbContext database,
            IValidator<CreateAccountDto> validator,
            IDtoPartialMapper<AccountEntity, AccountDto, CreateAccountDto> mapper) : base(database, validator, mapper)
        {
        }
    }
}
