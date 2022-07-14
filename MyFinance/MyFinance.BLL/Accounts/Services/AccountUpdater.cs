using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Accounts.Dto;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Accounts.Services
{
    public class AccountUpdater : BaseUpdateService<AccountEntity, FetchAccountDto, UpdateAccountDto>, IUpdater<AccountEntity, FetchAccountDto, UpdateAccountDto>
    {
        public AccountUpdater(
             IFinanceDbContext database,
             IValidator<UpdateAccountDto> validator) : base(database, validator)
        {}
    }
}
