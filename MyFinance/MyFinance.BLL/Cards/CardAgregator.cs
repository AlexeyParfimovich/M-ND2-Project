using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.BLL.Cards.Dto;
using MyFinance.DAL.Entities;

namespace MyFinance.BLL.Cards
{
    public class CardAgregator : 
        BaseAgregator<CardEntity, FetchCardDto, CreateCardDto, UpdateCardDto>,
        IAgregator<CardEntity, FetchCardDto, CreateCardDto, UpdateCardDto>
    {
        public CardAgregator(
            ICreator<CardEntity, FetchCardDto, CreateCardDto> creator,
            IUpdater<CardEntity, FetchCardDto, UpdateCardDto> updater,
            IFetcher<CardEntity, FetchCardDto> fetcher,
            IRemover<CardEntity> remover) : base(creator, updater, fetcher, remover)
        {}
    }
}
