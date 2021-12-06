using MyFinance.API.Models;
using MyFinance.BLL.Budgets.Dto;

namespace MyFinance.API.Controllers
{
    public static class BudgetModelMapper
    {
        public static CreateBudgetDto MapToDtoCreate(CreateBudgetModel model)
        {
            return new CreateBudgetDto
            {
                Name = model.Name,
                CurrencyType = model.CurrencyType,
            };
        }

        public static UpdateBudgetDto MapToDtoUpdate(UpdateBudgetModel model)
        {
            return new UpdateBudgetDto
            {
                Id = model.Id,
                Name = model.Name,
                CurrencyType = model.CurrencyType,
            };
        }

        public static BudgetModel MapToModel(BudgetDto dto)
        {
            return new BudgetModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Balance = dto.Balance,
                CurrencyType = dto.CurrencyType,
            };
        }
    }
}
