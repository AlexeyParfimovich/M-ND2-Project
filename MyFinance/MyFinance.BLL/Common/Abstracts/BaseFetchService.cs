using Microsoft.EntityFrameworkCore;
using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Common.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyFinance.BLL.Common.Abstracts
{
    public abstract class BaseFetchService<TEntity, TKey, TDto> : IFetcher<TEntity, TKey, TDto>
        where TEntity : BaseTypedEntity<TKey>
    {
        protected readonly IFinanceDbContext _db;
        protected readonly IContractMapper _mapper;

        public BaseFetchService(
            IFinanceDbContext database,
            IContractMapper mapper)
        {
            _db = database;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDto>> FetchAll()
        {
            var entities = await _db.Context.Set<TEntity>().ToListAsync();

            List<TDto> dtos = new();
            foreach (var entity in entities)
            {
                dtos.Add(_mapper.Map<TEntity, TDto>(entity));
            }

            return dtos;
        }

        public async Task<TDto> FetchByKey(TKey key)
        {
            var entity = await _db.Context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id.Equals(key));

            return _mapper.Map<TEntity, TDto>(entity);
        }

    }
}
