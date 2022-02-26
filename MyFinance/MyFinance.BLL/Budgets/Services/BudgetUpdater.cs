using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Budgets.Services
{
    public class BudgetUpdater : BaseUpdateService<BudgetEntity, FetchBudgetDto, UpdateBudgetDto>, IUpdater<BudgetEntity, FetchBudgetDto, UpdateBudgetDto>
    {
        public BudgetUpdater(
             IFinanceDbContext database,
             IValidator<UpdateBudgetDto> validator) : base(database, validator)
        {}
    }
}
