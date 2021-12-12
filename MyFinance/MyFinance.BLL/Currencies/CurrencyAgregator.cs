using MyFinance.DAL.Entities;
using MyFinance.BLL.Currencies.Dto;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Currencies
{
    public class CurrencyAgregator :
        BaseAgregator<CurrencyEntity, string, CurrencyDto, CreateCurrencyDto, UpdateCurrencyDto>,
        IAgregator<CurrencyEntity, string, CurrencyDto, CreateCurrencyDto, UpdateCurrencyDto>
    {
        public CurrencyAgregator(
            ICreator<CurrencyEntity, CurrencyDto, CreateCurrencyDto> creator,
            IUpdater<CurrencyEntity, CurrencyDto, UpdateCurrencyDto> updater,
            IFetcher<CurrencyEntity, string, CurrencyDto> fetcher,
            IRemover<CurrencyEntity, string> remover) : base(creator, updater, fetcher, remover)
        {
        }
    }
}
