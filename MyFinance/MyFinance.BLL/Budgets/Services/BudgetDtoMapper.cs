using MyFinance.BLL.Budgets.Dto;
using MyFinance.DAL.Entities;

namespace MyFinance.BLL.Budgets.Services
{
    public static class BudgetDtoMapper
    {
        public static BudgetEntity MapToEntityCreate(CreateBudgetDto dto)
        {
            return new BudgetEntity
            {
                Name = dto.Name,
                CurrencyType = dto.CurrencyType,
            };
        }

        public static BudgetEntity MapToEntityUpdate(UpdateBudgetDto dto)
        {
            return new BudgetEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                CurrencyType = dto.CurrencyType,
            };
        }

        public static BudgetDto MapToDto(BudgetEntity entity)
        {
            return new BudgetDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Balance = entity.Balance,
                CurrencyType = entity.CurrencyType,
            };
        }
    }
}
