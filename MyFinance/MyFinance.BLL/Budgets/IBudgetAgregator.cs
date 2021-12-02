using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.BLL.Budgets
{
    public interface IBudgetAgregator
    {
        ICreator<CreateBudgetDto, BudgetDto> Creator { get; }

        IUpdater<UpdateBudgetDto, BudgetDto> Updater { get; }

        IFetcher<long, BudgetDto> Fetcher { get; }

        IRemover<long> Remover { get; }
    }
}
