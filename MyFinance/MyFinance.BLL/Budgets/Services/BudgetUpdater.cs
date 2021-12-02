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
    public class BudgetUpdater : IUpdater<UpdateBudgetDto, BudgetDto>
    {
        private readonly IFinanceDbContext _db;
        private readonly IValidator<UpdateBudgetDto> _validator;

        public BudgetUpdater(
            IFinanceDbContext database,
            IValidator<UpdateBudgetDto> validator)
        {
            _db = database;
            _validator = validator;
        }

        public async Task<BudgetDto> Update(UpdateBudgetDto dto)
        {
            await _validator.Validate(dto);
            var entity = BudgetMapper.MapToEntityUpdate(dto);
            var entry = _db.Context.Budgets.Update(entity);
            await _db.Context.SaveChangesAsync();

            return BudgetMapper.MapToDto(entry.Entity);
        }
    }
}
