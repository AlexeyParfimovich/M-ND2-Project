using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MyFinance.DAL.Entities;

namespace MyFinance.DAL.Interfaces
{
    public interface IBaseRepository<TModel, TKey> where TModel : BaseEntity<TKey>
    {
        Task<TModel> GetById(TKey id);

        Task<IEnumerable<TModel>> GetAll();

        Task<IEnumerable<TModel>> Find(Func<TModel, Boolean> predicate);

        Task<TModel> Create(TModel item);

        Task<IEnumerable<TModel>> CreateRange(IEnumerable<TModel> entities);

        Task<TModel> Update(TModel item);

        Task<IEnumerable<TModel>> UpdateRange(IEnumerable<TModel> entities);

        Task Delete(TKey id);

        Task Clear();

    }
}
