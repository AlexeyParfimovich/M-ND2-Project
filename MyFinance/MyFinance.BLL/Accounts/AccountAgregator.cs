using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.BLL.Accounts.Dto;
using MyFinance.DAL.Entities;

namespace MyFinance.BLL.Accounts
{
    public class AccountAgregator :
        BaseAgregator<AccountEntity, FetchAccountDto, CreateAccountDto, UpdateAccountDto>,
        IAgregator<AccountEntity, FetchAccountDto, CreateAccountDto, UpdateAccountDto>
    {
        public AccountAgregator(
            ICreator<AccountEntity, FetchAccountDto, CreateAccountDto> creator,
            IUpdater<AccountEntity, FetchAccountDto, UpdateAccountDto> updater,
            IFetcher<AccountEntity, FetchAccountDto> fetcher,
            IRemover<AccountEntity> remover) : base(creator, updater, fetcher, remover)
        {}
    }
}
