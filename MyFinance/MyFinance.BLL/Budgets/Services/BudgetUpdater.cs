using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Budgets.Services
{
    public class BudgetUpdater : BaseUpdateService<BudgetEntity, BudgetDto, UpdateBudgetDto>, IUpdater<BudgetEntity, BudgetDto, UpdateBudgetDto>
    {
        public BudgetUpdater(
             IFinanceDbContext database,
             IValidator<UpdateBudgetDto> validator,
             IDtoPartialMapper<BudgetEntity, BudgetDto, UpdateBudgetDto> mapper) : base(database, validator, mapper)
        {
        }
    }
}
