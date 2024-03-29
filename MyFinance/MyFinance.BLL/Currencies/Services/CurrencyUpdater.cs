﻿using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.BLL.Currencies.Dto;

namespace MyFinance.BLL.Currencies.Services
{
    public class CurrencyUpdater : BaseUpdateService<CurrencyEntity, FetchCurrencyDto, UpdateCurrencyDto>, IUpdater<CurrencyEntity, FetchCurrencyDto, UpdateCurrencyDto>
    {
        public CurrencyUpdater(
             IFinanceDbContext database,
             IValidator<UpdateCurrencyDto> validator) : base(database, validator)
        {}
    }
}
