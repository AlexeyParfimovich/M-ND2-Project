using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Abstracts;
using MyFinance.BLL.Accounts.Dto;
using MyFinance.BLL.Interfaces;

namespace MyFinance.BLL.Accounts.Services
{
    public class AccountFetcher : BaseFetchService<AccountEntity, long, AccountDto>, IFetcher<AccountEntity, long, AccountDto>
    {
        public AccountFetcher(
            IFinanceDbContext database,
            IDtoMapper<AccountEntity, AccountDto> mapper) : base (database, mapper)
        {
        }
    }
}
