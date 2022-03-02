using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Accounts.Dto;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Accounts.Services
{
    public class AccountFetcher : BaseFetchService<AccountEntity, FetchAccountDto>, IFetcher<AccountEntity, FetchAccountDto>
    {
        public AccountFetcher(
            IFinanceDbContext database) : base (database)
        {}
    }
}
