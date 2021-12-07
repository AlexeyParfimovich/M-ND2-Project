using MyFinance.BLL.Accounts.Services;
using MyFinance.BLL.Interfaces;
using MyFinance.DAL;
using MyFinance.DAL.Entities;
using System.Threading.Tasks;

namespace MyFinance.BLL.Abstracts
{
    public abstract class BaseCreateService<TEntity, TCreateDto, TDto>: ICreator<TCreateDto, TDto>
        where TEntity : BaseEntity
    {
        protected readonly IFinanceDbContext _db;
        protected readonly IValidator<TCreateDto> _validator;
        //protected readonly IMapper<TEntity, TDto, TCreateDto, TUpdateDto> _mapper;

        public BaseCreateService(
            IFinanceDbContext database,
            IValidator<TCreateDto> validator)
        {
            _db = database;
            _validator = validator;
        }

        public async Task<TDto> Create(TCreateDto dto)
        {
            await _validator.Validate(dto);

            var entity = AccountDtoMapper.MapToEntityCreate(dto);

            var entry = await _db.Context.Set<TEntity>().AddAsync(entity);

            await _db.Context.SaveChangesAsync();

            return AccountDtoMapper.MapToDto(entry.Entity);
        }
    }
}
