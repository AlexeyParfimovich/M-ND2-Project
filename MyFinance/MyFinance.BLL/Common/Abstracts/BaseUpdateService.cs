﻿using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.BLL.Common.Infrastructure;
using System.Threading.Tasks;
using System.Collections;
using System.Linq;

namespace MyFinance.BLL.Common.Abstracts
{
    public abstract class BaseUpdateService<TEntity, TDto, TPartialDto> : IUpdater<TEntity, TDto, TPartialDto>
        where TEntity : BaseEntity
    {
        protected readonly IFinanceDbContext _db;
        protected readonly IValidator<TPartialDto> _validator;

        public BaseUpdateService(
            IFinanceDbContext database,
            IValidator<TPartialDto> validator)
        {
            _db = database;
            _validator = validator;
        }

        public virtual async Task<TDto> Update(TPartialDto dto)
        {
            await _validator.Validate(dto);

            var entity = ContractsMapper.Map<TPartialDto, TEntity>(dto);
            var entry = _db.Context.Set<TEntity>().Update(entity);

            foreach(var property in entry.Properties)
            {
                property.IsModified = property.CurrentValue is not null && property.IsModified;
            }

            await _db.Context.SaveChangesAsync();

            await entry.ReloadAsync();

            return ContractsMapper.Map<TEntity, TDto>(entry.Entity);
        }
    }
}
