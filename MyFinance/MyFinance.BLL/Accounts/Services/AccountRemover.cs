using Microsoft.EntityFrameworkCore;
using MyFinance.BLL.Abstracts;
using MyFinance.BLL.Interfaces;
using MyFinance.DAL;
using System.Threading.Tasks;

namespace MyFinance.BLL.Accounts.Services
{
    public class AccountRemover : BaseService, IRemover<long>
    {
        public AccountRemover(IFinanceDbContext database) : base(database)
        {
        }

        public async Task Remove(long key)
        {
            var entity = await _db.Context.Accounts.FirstOrDefaultAsync(x => x.Id == key);

            if (entity is not null)
            {
                _db.Context.Accounts.Remove(entity);
                await _db.Context.SaveChangesAsync();
            }
        }
    }
}
