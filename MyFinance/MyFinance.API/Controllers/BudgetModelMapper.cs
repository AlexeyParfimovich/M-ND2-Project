using MyFinance.API.Models;
using MyFinance.BLL.Budgets.Dto;
using Newtonsoft.Json;

namespace MyFinance.API.Controllers
{
    public static class BudgetModelMapper
    {
        public static CreateBudgetDto MapToDtoCreate(CreateBudgetModel model)
        {
            return new CreateBudgetDto
            {
                Name = model.Name,
                CurrencyId = model.CurrencyId,
            };
        }

        public static UpdateBudgetDto MapToDtoUpdate(UpdateBudgetModel model)
        {
            return new UpdateBudgetDto
            {
                Id = model.Id,
                Name = model.Name,
                CurrencyId = model.CurrencyId,
            };
        }

        public static BudgetModel MapToModel(BudgetDto dto)
        {
            return JsonConvert.DeserializeObject<BudgetModel>(
                JsonConvert.SerializeObject(dto));
            /*
            return new BudgetModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Balance = dto.Balance,
                CurrencyId = dto.CurrencyId,
            };
            */
        }
    }
}
