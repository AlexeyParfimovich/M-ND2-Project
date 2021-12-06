using Microsoft.EntityFrameworkCore;
using MyFinance.BLL.Abstracts;
using MyFinance.BLL.Interfaces;
using MyFinance.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.BLL.Budgets.Services
{
    public class BudgetRemover : BaseService, IRemover<long>
    {
        public BudgetRemover(IFinanceDbContext database): base(database)
        {
        }

        public async Task Remove(long key)
        {
            var entity = await _db.Context.Budgets.FirstOrDefaultAsync(x => x.Id == key);

            if (entity is not null)
            {
                _db.Context.Budgets.Remove(entity);
                await _db.Context.SaveChangesAsync();
            }
        }
    }
}
