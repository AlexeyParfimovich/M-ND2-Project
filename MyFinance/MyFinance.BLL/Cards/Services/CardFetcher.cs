using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.BLL.Cards.Dto;

namespace MyFinance.BLL.Cards.Services
{
    public class CardFetcher : BaseFetchService<CardEntity, FetchCardDto>, IFetcher<CardEntity, FetchCardDto>
    {
        public CardFetcher(
            IFinanceDbContext database) : base (database)
        {}
    }
}
