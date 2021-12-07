using MyFinance.BLL.Abstracts;
using MyFinance.BLL.Interfaces;
using MyFinance.BLL.Accounts.Dto;

namespace MyFinance.BLL.Accounts
{
    public class AccountAgregator :
        BaseAgregator<long, AccountDto, CreateAccountDto, UpdateAccountDto>,
        IAgregator<long, AccountDto, CreateAccountDto, UpdateAccountDto>
    {
        public AccountAgregator(
            ICreator<CreateAccountDto, AccountDto> creator,
            IUpdater<UpdateAccountDto, AccountDto> updater,
            IFetcher<long, AccountDto> fetcher,
            IRemover<long> remover) : base(creator, updater, fetcher, remover)
        {
        }
    }
}
