using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Budgets.Services
{
    public class BudgetCreator : BaseCreateService<BudgetEntity, BudgetDto, CreateBudgetDto>, ICreator<BudgetEntity, BudgetDto, CreateBudgetDto>
    {
        public BudgetCreator(
            IFinanceDbContext database,
            IValidator<CreateBudgetDto> validator,
            IContractMapper mapper) : base(database, validator, mapper)
        {
        }
    }
}
