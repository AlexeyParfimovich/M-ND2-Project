using MyFinance.DAL.Entities;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Budgets.Services
{
    public class BudgetCreateMapper: IDtoPartialMapper<BudgetEntity, BudgetDto, CreateBudgetDto>
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

        public BudgetEntity DtoToEntity(CreateBudgetDto dto)
        {
            return new BudgetEntity
            {
                Name = dto.Name,
                CurrencyId = dto.CurrencyId,
            };
        }
    }
}
