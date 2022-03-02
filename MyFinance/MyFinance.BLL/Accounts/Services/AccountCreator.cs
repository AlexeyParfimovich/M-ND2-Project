using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Accounts.Dto;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Accounts.Services
{
    public class AccountCreator : BaseCreateService<AccountEntity, FetchAccountDto, CreateAccountDto>, ICreator<AccountEntity, FetchAccountDto, CreateAccountDto>
    {
        public AccountCreator(
            IFinanceDbContext database,
            IValidator<CreateAccountDto> validator) : base(database, validator)
        {}
    }
}
