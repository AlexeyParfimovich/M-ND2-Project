using Microsoft.EntityFrameworkCore;
using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Interfaces;
using System.Threading.Tasks;

namespace MyFinance.BLL.Abstracts
{
    public abstract class BaseRemoveService<TEntity, TKey> : IRemover<TEntity, TKey>
        where TEntity : BaseTypedEntity<TKey>
    {
        protected readonly IFinanceDbContext _db;

        public BaseRemoveService(IFinanceDbContext database)
        {
            _db = database;
        }

        public async Task Remove(TKey key)
        {
            var entity = await _db.Context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id.Equals(key));

            if (entity is not null)
            {
                _db.Context.Set<TEntity>().Remove(entity);
                await _db.Context.SaveChangesAsync();
            }
        }
    }
}
