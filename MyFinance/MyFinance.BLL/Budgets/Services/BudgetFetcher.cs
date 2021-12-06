using Microsoft.EntityFrameworkCore;
using MyFinance.BLL.Abstracts;
using MyFinance.BLL.Budgets.Dto;
using MyFinance.BLL.Interfaces;
using MyFinance.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.BLL.Budgets.Services
{
    public class BudgetFetcher : BaseService ,IFetcher<long, BudgetDto>
    {
        public BudgetFetcher(IFinanceDbContext database) : base(database)
        {
        }

        public async Task<IEnumerable<BudgetDto>> FetchAll()
        {
            var entities = await _db.Context.Budgets.ToListAsync();

            List<BudgetDto> dtos = new();
            foreach (var entity in entities)
            {
                dtos.Add(BudgetDtoMapper.MapToDto(entity));
            }

            return dtos;
        }

        public async Task<BudgetDto> FetchByKey(long key)
        {
            var entity = await _db.Context.Budgets.FirstOrDefaultAsync(x => x.Id == key);

            return BudgetDtoMapper.MapToDto(entity);
        }
    }
}
