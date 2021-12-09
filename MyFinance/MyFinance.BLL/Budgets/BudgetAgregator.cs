using MyFinance.BLL.Abstracts;
using MyFinance.BLL.Interfaces;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.DAL.Entities;

namespace MyFinance.BLL.Budgets
{
    public class BudgetAgregator : 
        BaseAgregator<BudgetEntity, long, BudgetDto, CreateBudgetDto, UpdateBudgetDto>,
        IAgregator<BudgetEntity, long, BudgetDto, CreateBudgetDto, UpdateBudgetDto>
    {
        public BudgetAgregator(
            ICreator<BudgetEntity, BudgetDto, CreateBudgetDto> creator,
            IUpdater<BudgetEntity, BudgetDto, UpdateBudgetDto> updater,
            IFetcher<BudgetEntity, long, BudgetDto> fetcher,
            IRemover<BudgetEntity, long> remover) : base(creator, updater, fetcher, remover)
        {
        }
    }
}
