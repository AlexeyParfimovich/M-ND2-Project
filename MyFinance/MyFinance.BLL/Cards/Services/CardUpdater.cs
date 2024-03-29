﻿using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.BLL.Cards.Dto;

namespace MyFinance.BLL.Cards.Services
{
    public class CardUpdater : BaseUpdateService<CardEntity, FetchCardDto, UpdateCardDto>, IUpdater<CardEntity, FetchCardDto, UpdateCardDto>
    {
        public CardUpdater(
             IFinanceDbContext database,
             IValidator<UpdateCardDto> validator) : base(database, validator)
        {}
    }
}
