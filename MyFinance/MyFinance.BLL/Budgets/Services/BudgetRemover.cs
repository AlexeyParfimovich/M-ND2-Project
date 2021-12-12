using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Budgets.Services
{
    public class BudgetRemover : BaseRemoveService<BudgetEntity, long>, IRemover<BudgetEntity, long>
    {
        public BudgetRemover(IFinanceDbContext database): base(database)
        {
        }
    }
}
