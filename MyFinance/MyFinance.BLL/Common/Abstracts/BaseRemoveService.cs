using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.BLL.Common.Infrastructure;
using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyFinance.BLL.Common.Exceptions;

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

        public virtual async Task Remove(QueryFilter filter)
        {
            if (filter is null)
            {
                throw new DataNullReferenceException();
            }

            if (filter.Conditions is null)
            {
                throw new ValueNotSpecifiedException($"Filter conditions not specified");
            }

            var parameter = Expression.Parameter(typeof(TEntity), "p");
            var lambdaExpr = Expression.Lambda(
                        FilterExpressionCreator.GetConditionsExpression(filter.Conditions.ToArray(), parameter),
                        new List<ParameterExpression>() { parameter });

            var entity = await _db.Context.Set<TEntity>().FirstOrDefaultAsync((Expression<Func<TEntity, bool>>)lambdaExpr);
            if (entity is null)
            {
                throw new ValueNotFoundException($"Entities specified by the filter conditions {{ {filter} }} were not found");
            }

            _db.Context.Set<TEntity>().Remove(entity);
            await _db.Context.SaveChangesAsync();
        }
    }
}
