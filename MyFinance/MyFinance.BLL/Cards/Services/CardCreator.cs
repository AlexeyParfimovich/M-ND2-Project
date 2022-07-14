using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.BLL.Cards.Dto;

namespace MyFinance.BLL.Cards.Services
{
    public class CardCreator : BaseCreateService<CardEntity, FetchCardDto, CreateCardDto>, ICreator<CardEntity, FetchCardDto, CreateCardDto>
    {
        public CardCreator(
            IFinanceDbContext database,
            IValidator<CreateCardDto> validator) : base(database, validator)
        {}
    }
}
