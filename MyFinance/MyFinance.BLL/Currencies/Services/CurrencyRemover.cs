using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;

namespace MyFinance.BLL.Currencies.Services
{
    public class CurrencyRemover : BaseRemoveService<CurrencyEntity>, IRemover<CurrencyEntity>
    {
        public CurrencyRemover(IFinanceDbContext database): base(database)
        {
        }
    }
}
