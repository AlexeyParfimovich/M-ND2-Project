using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Interfaces;
using System;
using System.Threading.Tasks;

namespace MyFinance.BLL.Budgets.Services
{
    public class BudgetUpdateValidator : IValidator<UpdateBudgetDto>
    {
        public Task Validate(UpdateBudgetDto dto)
        {
            if (dto is null)
            {
                throw new NullReferenceException();
            }

            /*
            * TODO: Implement Id validation
            */

            /*
             * TODO: Implement CurrencyType validation
             */

            return Task.CompletedTask;
        }
    }
}
