using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Accounts.Services
{
    public class AccountRemover : BaseRemoveService<AccountEntity, long>, IRemover<AccountEntity, long>
    {
        public AccountRemover(IFinanceDbContext database): base(database)
        {
        }
    }
}
