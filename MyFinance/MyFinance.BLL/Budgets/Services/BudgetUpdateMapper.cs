using MyFinance.DAL.Entities;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Common.Interfaces;

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
            var entity = new BudgetEntity();

            foreach(var prop in dto.GetType().GetProperties())
            {
                switch (prop.Name)
                {
                    case "Id": 
                        entity.Id = (long)prop.GetValue(dto);
                        break;
                    case "Name":
                        entity.Name = (string)prop.GetValue(dto);
                        break;
                    case "Balance":
                        entity.Balance = (decimal)prop.GetValue(dto);
                        break;
                    case "CurrencyId":
                        entity.CurrencyId = (string)prop.GetValue(dto);
                        break;
                }
            }
            return entity;
        }
    }
}
