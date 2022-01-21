using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Budgets.Services
{
    public class BudgetFetcher : BaseFetchService<BudgetEntity, FetchBudgetDto>, IFetcher<BudgetEntity, FetchBudgetDto>
    {
        public BudgetFetcher(
            IFinanceDbContext database) : base (database)
        {
        }
    }
}
