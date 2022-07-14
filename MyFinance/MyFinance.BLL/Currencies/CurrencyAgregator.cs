using MyFinance.DAL.Entities;
using MyFinance.BLL.Currencies.Dto;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Currencies
{
    public class CurrencyAgregator :
        BaseAgregator<CurrencyEntity, FetchCurrencyDto, CreateCurrencyDto, UpdateCurrencyDto>,
        IAgregator<CurrencyEntity, FetchCurrencyDto, CreateCurrencyDto, UpdateCurrencyDto>
    {
        public CurrencyAgregator(
            ICreator<CurrencyEntity, FetchCurrencyDto, CreateCurrencyDto> creator,
            IUpdater<CurrencyEntity, FetchCurrencyDto, UpdateCurrencyDto> updater,
            IFetcher<CurrencyEntity, FetchCurrencyDto> fetcher,
            IRemover<CurrencyEntity> remover) : base(creator, updater, fetcher, remover)
        {}
    }
}
