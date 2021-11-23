using MyFinance.DAL.Entities;
using MyFinance.DAL.Interfaces;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MyFinance.DAL.Repositories
{
    public abstract class BaseRepository<TModel, TKey> : IBaseRepository<TModel, TKey>
        where TModel : BaseEntity<TKey>
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task Clear()
        {
            throw new NotImplementedException();
        }

        public Task<TModel> Create(TModel item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TModel>> CreateRange(IEnumerable<TModel> entities)
        {
            throw new NotImplementedException();
        }

        public Task Delete(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TModel>> Find(Func<TModel, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TModel> GetById(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> Update(TModel item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TModel>> UpdateRange(IEnumerable<TModel> entities)
        {
            throw new NotImplementedException();
        }
    }
}
