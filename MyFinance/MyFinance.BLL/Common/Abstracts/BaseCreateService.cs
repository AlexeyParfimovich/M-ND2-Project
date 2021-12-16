using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Common.Interfaces;
using System.Threading.Tasks;
using System;
using MyFinance.BLL.Common.Exceptions;

namespace MyFinance.BLL.Common.Abstracts
{
    public abstract class BaseCreateService<TEntity, TDto, TPartialDto>: ICreator<TEntity, TDto, TPartialDto>
        where TEntity : BaseEntity
    {
        protected readonly IFinanceDbContext _db;
        protected readonly IValidator<TPartialDto> _validator;
        protected readonly IContractMapper _mapper;

        public BaseCreateService(
            IFinanceDbContext database,
            IValidator<TPartialDto> validator,
            IContractMapper mapper)
        {
            _db = database;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<TDto> Create(TPartialDto dto)
        {
            await _validator.Validate(dto);

            var entity = _mapper.Map<TPartialDto, TEntity>(dto);

            using var transaction = await _db.Context.Database.BeginTransactionAsync();

            try
            {
                var entry = await _db.Context.Set<TEntity>().AddAsync(entity);

                await _db.Context.SaveChangesAsync();

                var result  = _mapper.Map<TEntity, TDto>(entry.Entity);

                await transaction.CommitAsync();

                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                throw new DataSaveChangesException($"Error saving new {entity.GetType().Name}", ex);
            }
        }
    }
}
