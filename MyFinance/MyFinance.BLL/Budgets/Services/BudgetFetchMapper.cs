using MyFinance.DAL.Entities;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Common.Interfaces;
using Newtonsoft.Json;

namespace MyFinance.BLL.Budgets.Services
{
    public class BudgetFetchMapper : IDtoMapper<BudgetEntity, BudgetDto>
    {
        public BudgetDto EntityToDto(BudgetEntity entity)
        {
            return JsonConvert.DeserializeObject<BudgetDto>(
                JsonConvert.SerializeObject(entity));
            /*
            return new BudgetDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Balance = entity.Balance,
                CurrencyId = entity.CurrencyId,
            };
            */
        }
    }
}
