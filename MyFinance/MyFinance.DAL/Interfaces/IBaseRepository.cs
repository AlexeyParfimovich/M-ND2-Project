using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MyFinance.DAL.Entities;

namespace MyFinance.DAL.Interfaces
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<TEntity> GetById(TKey id);

        Task<IEnumerable<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> Find(Func<TEntity, Boolean> predicate);

        Task<TEntity> Create(TEntity entity);

        Task<IEnumerable<TEntity>> CreateRange(IEnumerable<TEntity> entities);

        Task<TEntity> Update(TEntity entity);

        Task<IEnumerable<TEntity>> UpdateRange(IEnumerable<TEntity> entities);

        Task Delete(TKey id);

        Task Clear();

    }
}
