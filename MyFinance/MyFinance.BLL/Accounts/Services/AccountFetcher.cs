using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Accounts.Dto;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Accounts.Services
{
    public class AccountFetcher : BaseFetchService<AccountEntity, long, AccountDto>, IFetcher<AccountEntity, long, AccountDto>
    {
        public AccountFetcher(
            IFinanceDbContext database,
            IContractMapper mapper) : base (database, mapper)
        {
        }
    }
}
