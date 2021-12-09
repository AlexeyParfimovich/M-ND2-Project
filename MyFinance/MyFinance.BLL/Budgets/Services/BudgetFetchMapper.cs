using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Interfaces;
using MyFinance.DAL.Entities;

namespace MyFinance.BLL.Budgets.Services
{
    public class BudgetFetchMapper : IDtoMapper<BudgetEntity, BudgetDto>
    {
        public BudgetDto EntityToDto(BudgetEntity entity)
        {
            return new BudgetDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Balance = entity.Balance,
                CurrencyId = entity.CurrencyId,
            };
        }
    }
}
