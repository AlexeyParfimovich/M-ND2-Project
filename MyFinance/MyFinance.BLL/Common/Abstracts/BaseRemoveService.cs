using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.BLL.Common.Infrastructure;
using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyFinance.BLL.Common.Abstracts
{
    public abstract class BaseRemoveService<TEntity> : IRemover<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly IFinanceDbContext _db;

        public BaseRemoveService(IFinanceDbContext database)
        {
            _db = database;
        }

        public async Task Remove(QueryFilter filter)
        {
            if (filter is null || filter.Conditions is null)
            {
                // throw exception
            }

            var parameter = Expression.Parameter(typeof(TEntity), "p");
            var lambdaExpr = Expression.Lambda(
                        FilterExpressionCreator.GetConditionsExpression(filter.Conditions.ToArray(), parameter),
                        new List<ParameterExpression>() { parameter });

            var entity = await _db.Context.Set<TEntity>().FirstOrDefaultAsync((Expression<Func<TEntity, bool>>)lambdaExpr);

            if (entity is not null)
            {
                _db.Context.Set<TEntity>().Remove(entity);
                await _db.Context.SaveChangesAsync();
            }
        }
    }
}
