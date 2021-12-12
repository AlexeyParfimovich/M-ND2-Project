using MyFinance.BLL.Cards.Dto;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.DAL.Entities;

namespace MyFinance.BLL.Cards.Services
{
    public class CardUpdateMapper : IDtoPartialMapper<CardEntity, CardDto, UpdateCardDto>
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

        public CardEntity DtoToEntity(UpdateCardDto dto)
        {
            return new CardEntity
            {
                Id = dto.Id,
                ValidThru = dto.ValidThru,
                AccountId = dto.AccountId,
            };
        }
    }
}
