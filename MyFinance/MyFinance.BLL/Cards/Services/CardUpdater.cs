using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.BLL.Cards.Dto;

namespace MyFinance.BLL.Cards.Services
{
    public class CardUpdater : BaseUpdateService<CardEntity, CardDto, UpdateCardDto>, IUpdater<CardEntity, CardDto, UpdateCardDto>
    {
        public CardUpdater(
             IFinanceDbContext database,
             IValidator<UpdateCardDto> validator,
             IDtoPartialMapper<CardEntity, CardDto, UpdateCardDto> mapper) : base(database, validator, mapper)
        {
        }
    }
}
