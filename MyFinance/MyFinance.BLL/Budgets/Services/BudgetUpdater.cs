using MyFinance.BLL.Abstracts;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Interfaces;
using MyFinance.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.BLL.Budgets.Services
{
    public class BudgetUpdater : BaseService, IUpdater<UpdateBudgetDto, BudgetDto>
    {
        protected readonly IValidator<UpdateBudgetDto> _validator;

        public BudgetUpdater(
            IFinanceDbContext database,
            IValidator<UpdateBudgetDto> validator): base(database)
        {
            _validator = validator;
        }

        public async Task<BudgetDto> Update(UpdateBudgetDto dto)
        {
            await _validator.Validate(dto);
            var entity = BudgetDtoMapper.MapToEntityUpdate(dto);
            var entry = _db.Context.Budgets.Update(entity);
            await _db.Context.SaveChangesAsync();

            return BudgetDtoMapper.MapToDto(entry.Entity);
        }
    }
}
