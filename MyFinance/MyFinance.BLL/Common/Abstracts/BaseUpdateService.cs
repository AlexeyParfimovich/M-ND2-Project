using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Common.Interfaces;
using System.Threading.Tasks;

namespace MyFinance.BLL.Common.Abstracts
{
    public abstract class BaseUpdateService<TEntity, TDto, TPartialDto> : IUpdater<TEntity, TDto, TPartialDto>
        where TEntity : BaseEntity
    {
        protected readonly IFinanceDbContext _db;
        protected readonly IValidator<TPartialDto> _validator;
        protected readonly IContractMapper _mapper;

        public BaseUpdateService(
            IFinanceDbContext database,
            IValidator<TPartialDto> validator,
            IContractMapper mapper)
        {
            _db = database;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<TDto> Update(TPartialDto dto)
        {
            await _validator.Validate(dto);

            var entity = _mapper.Map<TPartialDto, TEntity>(dto);

            var entry = _db.Context.Set<TEntity>().Update(entity);

            await _db.Context.SaveChangesAsync();

            return _mapper.Map<TEntity, TDto>(entry.Entity);
        }
    }
}
