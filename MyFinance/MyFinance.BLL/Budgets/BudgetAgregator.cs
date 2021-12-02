using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Interfaces;

namespace MyFinance.BLL.Budgets
{
    public class BudgetAgregator : IBudgetAgregator
    {
        private readonly ICreator<CreateBudgetDto, BudgetDto> _creator;
        private readonly IUpdater<UpdateBudgetDto, BudgetDto> _updater;
        private readonly IFetcher<long, BudgetDto> _fetcher;
        private readonly IRemover<long> _remover;

        public BudgetAgregator(
            ICreator<CreateBudgetDto, BudgetDto> creator,
            IUpdater<UpdateBudgetDto, BudgetDto> updater,
            IFetcher<long, BudgetDto> fetcher,
            IRemover<long> remover)
        {
            _creator = creator;
            _updater = updater;
            _fetcher = fetcher;
            _remover = remover;
        }

        public ICreator<CreateBudgetDto, BudgetDto> Creator => _creator;

        public IUpdater<UpdateBudgetDto, BudgetDto> Updater => _updater;

        public IFetcher<long, BudgetDto> Fetcher => _fetcher;

        public IRemover<long> Remover => _remover;
    }
}
