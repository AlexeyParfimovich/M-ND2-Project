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
        
        public async Task<IEnumerable<TDto>> FetchByFilter(QueryFilter filter)
        {
            if (filter is null || filter.Conditions is null)
            {
                // throw exception
            }

            var query = _db.Context.Set<TEntity>().AsQueryable();

            var parameter = Expression.Parameter(typeof(TEntity), "p");

            var lambdaExpr = Expression.Lambda(
                FilterExpressionCreator.GetConditionsExpression(filter.Conditions.ToArray(), parameter), 
                new ParameterExpression[] { parameter });

            query = query.Where((Expression<Func<TEntity, bool>>)lambdaExpr);

            var entities = await query.ToListAsync();

            return ContractsMapper.MapEnumarable<TEntity, TDto>(entities);
        }

        protected async Task<IEnumerable<TEntity>> FetchAllByCondition(
            Func<IQueryable<TEntity>, IQueryable<TEntity>> condition)
        {
            var query = _db.Context.Set<TEntity>().AsQueryable();

            if (condition is not null)
            {
                query = condition(query);
            }

            /*
            if (sortModel is not null &&
                !string.IsNullOrWhiteSpace(sortModel.PropertyName) &&
                sortModel.OrderDirection is not null)
            {
                var parameter = Expression.Parameter(typeof(TEntity));
                var properties = sortModel.PropertyName.Split('.');

                Expression lastMember = parameter;

                foreach (var property in properties)
                {
                    MemberExpression member = Expression.Property(lastMember, property);
                    lastMember = member;
                }

                var propertyAsObject = Expression.Convert(lastMember, typeof(object));
                var expression = Expression.Lambda<Func<TEntity, object>>(propertyAsObject, parameter);

                if (sortModel.OrderDirection == OrderDirection.Asc)
                {
                    query = query.OrderBy(expression);
                }
                else if (sortModel.OrderDirection == OrderDirection.Desc)
                {
                    query = query.OrderByDescending(expression);
                }
            }
            */

            return await query.ToListAsync();
        }

    }
}
