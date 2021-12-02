using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.BLL.Budgets.Services
{
    public class BudgetCreateValidator : IValidator<CreateBudgetDto>
    {
        public Task Validate(CreateBudgetDto dto)
        {
            if (dto is null)
            {
                throw new NullReferenceException();
            }

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ArgumentNullException(dto.Name);
            }

            /*
             * TODO: Implement CurrencyType validation
             */

            return Task.CompletedTask;
        }
    }
}
