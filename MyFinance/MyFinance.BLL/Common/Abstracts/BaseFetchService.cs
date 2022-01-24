using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.BLL.Common.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MyFinance.BLL.Common.Abstracts
{
    public abstract class BaseFetchService<TEntity, TDto> : IFetcher<TEntity, TDto>
        where TEntity : BaseEntity
    {
        protected readonly IFinanceDbContext _db;

        public BaseFetchService(IFinanceDbContext database)
        {
            _db = database;
        }

        public virtual async Task<IEnumerable<TDto>> FetchByFilter(QueryFilter filter)
        {
            var query = _db.Context.Set<TEntity>().AsQueryable();

            if (filter is not null && filter.Conditions.Count > 0)
            {
                var parameter = Expression.Parameter(typeof(TEntity), "p");

                var lambdaExpr = Expression.Lambda(
                    FilterExpressionCreator.GetConditionsExpression(filter.Conditions.ToArray(), parameter),
                    new ParameterExpression[] { parameter });

                query = query.Where((Expression<Func<TEntity, bool>>)lambdaExpr);
            }

            var entities = await query.ToListAsync();

            return ContractsMapper.MapEnumarable<TEntity, TDto>(entities);
        }
    }
}
