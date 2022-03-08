using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Cards.Dto;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.BLL.Common.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyFinance.BLL.Cards.Services
{
    public class CardFetcher : BaseFetchService<CardEntity, FetchCardDto>, IFetcher<CardEntity, FetchCardDto>
    {
        public CardFetcher(
            IFinanceDbContext database) : base (database)
        {}

        public override async Task<IEnumerable<FetchCardDto>> FetchFiltered(QueryFilter filter)
        {
            var condition = filter.GetCondition("BudgetId");
            if (condition is null)
                throw new ValueNotSpecifiedException("Budget Id is not specified");

            var accounts = await _db.Context.Accounts.AsNoTracking().AsQueryable().Where(x => x.BudgetId == (Guid)condition.Data).ToListAsync();
            if (accounts is null)
                return new List<FetchCardDto>();

            filter.RemoveCondition("BudgetId")
                .AddCondition("AccountId", accounts.ToArray())
                .Operator = ConditionOperator.OrElse;

            return await base.FetchFiltered(filter);
        }

        public override async Task<FetchCardDto> FetchFirst(QueryFilter filter)
        {
            var condition = filter.GetCondition("BudgetId");
            if (condition is null)
                throw new ValueNotSpecifiedException("Budget Id is not specified");

            filter.RemoveCondition("BudgetId");

            return await base.FetchFirst(filter);
        }
    }
}
