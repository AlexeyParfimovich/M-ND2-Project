using MyFinance.BLL.Abstracts;
using MyFinance.BLL.Interfaces;
using MyFinance.BLL.Budgets.Dto;

namespace MyFinance.BLL.Budgets
{
    public class BudgetAgregator : 
        BaseAgregator<long, BudgetDto, CreateBudgetDto, UpdateBudgetDto>,
        IAgregator<long, BudgetDto, CreateBudgetDto, UpdateBudgetDto>
    {
        public BudgetAgregator(
            ICreator<CreateBudgetDto, BudgetDto> creator,
            IUpdater<UpdateBudgetDto, BudgetDto> updater,
            IFetcher<long, BudgetDto> fetcher,
            IRemover<long> remover) : base(creator, updater, fetcher, remover)
        {
        }
    }
}
