using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Interfaces;
using System.Threading.Tasks;

namespace MyFinance.BLL.Abstracts
{
    public abstract class BaseUpdateService<TEntity, TDto, TPartialDto> : IUpdater<TEntity, TDto, TPartialDto>
        where TEntity : BaseEntity
    {
        protected readonly IFinanceDbContext _db;
        protected readonly IValidator<TPartialDto> _validator;
        protected readonly IDtoPartialMapper<TEntity, TDto, TPartialDto> _mapper;

        public BaseUpdateService(
            IFinanceDbContext database,
            IValidator<TPartialDto> validator,
            IDtoPartialMapper<TEntity, TDto, TPartialDto> mapper)
        {
            _db = database;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<TDto> Update(TPartialDto dto)
        {
            await _validator.Validate(dto);

            var entity = _mapper.DtoToEntity(dto);

            var entry = _db.Context.Set<TEntity>().Update(entity);

            await _db.Context.SaveChangesAsync();

            return _mapper.EntityToDto(entry.Entity);
        }
    }
}
