using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Interfaces;
using MyFinance.DAL.Entities;

namespace MyFinance.BLL.Budgets.Services
{
    public class BudgetUpdateMapper : IDtoPartialMapper<BudgetEntity, BudgetDto, UpdateBudgetDto>
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

        public BudgetEntity DtoToEntity(UpdateBudgetDto dto)
        {
            return new BudgetEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                CurrencyId = dto.CurrencyId,
            };
        }
    }
}
