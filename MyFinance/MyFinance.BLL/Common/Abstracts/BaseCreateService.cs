using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Common.Interfaces;
using System.Threading.Tasks;

namespace MyFinance.BLL.Common.Abstracts
{
    public abstract class BaseCreateService<TEntity, TDto, TPartialDto>: ICreator<TEntity, TDto, TPartialDto>
        where TEntity : BaseEntity
    {
        protected readonly IFinanceDbContext _db;
        protected readonly IValidator<TPartialDto> _validator;
        protected readonly IDtoPartialMapper<TEntity, TDto, TPartialDto> _mapper;

        public BaseCreateService(
            IFinanceDbContext database,
            IValidator<TPartialDto> validator,
            IDtoPartialMapper<TEntity, TDto, TPartialDto> mapper)
        {
            _db = database;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<TDto> Create(TPartialDto dto)
        {
            await _validator.Validate(dto);

            var entity = _mapper.DtoToEntity(dto);

            var entry = await _db.Context.Set<TEntity>().AddAsync(entity);

            await _db.Context.SaveChangesAsync();

            return _mapper.EntityToDto(entry.Entity);
        }
    }
}
