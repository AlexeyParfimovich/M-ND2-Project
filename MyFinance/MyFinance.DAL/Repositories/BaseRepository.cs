using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyFinance.DAL.Entities;
using MyFinance.DAL.Interfaces;

namespace MyFinance.DAL.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetById(TKey id) => await _context.Set<TEntity>()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        public async Task<IEnumerable<TEntity>> GetAll() => await _context.Set<TEntity>().ToListAsync();

        public async Task<IEnumerable<TEntity>> Find(Func<TEntity, bool> predicate) => await _context.Set<TEntity>()
            .Where(predicate).AsQueryable().ToListAsync();


        public async Task<TEntity> Create(TEntity entity)
        {
            if (entity is null) return null;

            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();

            return await _context.Set<TEntity>().FindAsync(entity.Id);
        }

        public async Task<IEnumerable<TEntity>> CreateRange(IEnumerable<TEntity> entities)
        {
            if (entities is null) return null;

            _context.Set<TEntity>().AddRange(entities);
            await _context.SaveChangesAsync();

            var ids = entities.Select(x => x.Id);

            return await _context.Set<TEntity>()
                .Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            if (entity is null) return null;

            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();

            return await _context.Set<TEntity>().FindAsync(entity.Id);
        }

        public async Task<IEnumerable<TEntity>> UpdateRange(IEnumerable<TEntity> entities)
        {
            if (entities is null) return null;

            _context.Set<TEntity>().UpdateRange(entities);
            await _context.SaveChangesAsync();

            var ids = entities.Select(x => x.Id);

            return await _context.Set<TEntity>()
                .Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task Delete(TKey id)
        {
            if (id is null) return;

            var entity = await _context.Set<TEntity>()
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (entity is not null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Clear()
        {
            var tableName = _context.Model.FindEntityType(typeof(TEntity)).GetTableName();
            var schemaName = _context.Model.FindEntityType(typeof(TEntity)).GetSchema() ?? "public";

            await _context.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE {schemaName}.{tableName}");
        }
    }
}
