using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Abstracts;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Interfaces;

namespace MyFinance.BLL.Budgets.Services
{
    public class BudgetFetcher : BaseFetchService<BudgetEntity, long, BudgetDto>, IFetcher<BudgetEntity, long, BudgetDto>
    {
        public BudgetFetcher(
            IFinanceDbContext database,
            IDtoMapper<BudgetEntity, BudgetDto> mapper) : base (database, mapper)
        {
        }
    }
}
