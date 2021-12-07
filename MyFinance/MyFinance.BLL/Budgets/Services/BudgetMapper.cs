using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Interfaces;
using MyFinance.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.BLL.Budgets.Services
{
    public class BudgetMapper : IMapper<BudgetEntity, BudgetDto, CreateBudgetDto, UpdateBudgetDto>
    {
        public BudgetEntity DtoToEntity(CreateBudgetDto dto)
        {
            return new BudgetEntity
            {
                Name = dto.Name,
                CurrencyType = dto.CurrencyType,
            };
        }

        public BudgetEntity DtoToEntity(UpdateBudgetDto dto)
        {
            return new BudgetEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                CurrencyType = dto.CurrencyType,
            };
        }

        public BudgetDto EntityToDto(BudgetEntity entity)
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
