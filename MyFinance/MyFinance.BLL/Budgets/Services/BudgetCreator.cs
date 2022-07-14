using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Budgets.Services
{
    public class BudgetCreator : BaseCreateService<BudgetEntity, FetchBudgetDto, CreateBudgetDto>, ICreator<BudgetEntity, FetchBudgetDto, CreateBudgetDto>
    {
        public BudgetCreator(
            IFinanceDbContext database,
            IValidator<CreateBudgetDto> validator) : base(database, validator)
        {
        }
    }
}
