using MyFinance.DAL.Entities;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Budgets
{
    public class BudgetAgregator : 
        BaseAgregator<BudgetEntity, FetchBudgetDto, CreateBudgetDto, UpdateBudgetDto>,
        IAgregator<BudgetEntity, FetchBudgetDto, CreateBudgetDto, UpdateBudgetDto>
    {
        public BudgetAgregator(
            ICreator<BudgetEntity, FetchBudgetDto, CreateBudgetDto> creator,
            IUpdater<BudgetEntity, FetchBudgetDto, UpdateBudgetDto> updater,
            IFetcher<BudgetEntity, FetchBudgetDto> fetcher,
            IRemover<BudgetEntity> remover) : base(creator, updater, fetcher, remover)
        {
        }
    }
}
