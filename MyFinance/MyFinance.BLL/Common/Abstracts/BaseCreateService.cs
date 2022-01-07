using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Common.Exceptions;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.BLL.Common.Infrastructure;
using System.Threading.Tasks;
using System;

namespace MyFinance.BLL.Common.Abstracts
{
    public abstract class BaseCreateService<TEntity, TDto, TPartialDto>: ICreator<TEntity, TDto, TPartialDto>
        where TEntity : BaseEntity
    {
        protected readonly IFinanceDbContext _db;
        protected readonly IValidator<TPartialDto> _validator;

        public BaseCreateService(
            IFinanceDbContext database,
            IValidator<TPartialDto> validator)
        {
            _db = database;
            _validator = validator;
        }

        public async Task<TDto> Create(TPartialDto dto)
        {
            await _validator.Validate(dto);

            var entity = ContractsMapper.Map<TPartialDto, TEntity>(dto);

            using var transaction = await _db.Context.Database.BeginTransactionAsync();

            try
            {
                var entry = await _db.Context.Set<TEntity>().AddAsync(entity);

                await _db.Context.SaveChangesAsync();

                var result  = ContractsMapper.Map<TEntity, TDto>(entry.Entity);

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
