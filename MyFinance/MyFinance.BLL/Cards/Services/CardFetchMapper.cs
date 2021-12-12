using MyFinance.BLL.Cards.Dto;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.DAL.Entities;

namespace MyFinance.BLL.Cards.Services
{
    public class CardFetchMapper : IDtoMapper<CardEntity, CardDto>
    {
        public CardDto EntityToDto(CardEntity entity)
        {
            return new CardDto
            {
                Id = entity.Id,
                ValidThru = entity.ValidThru,
                AccountId = entity.AccountId,
                LastTransaction = entity.LastTransaction,
            };
        }
    }
}
