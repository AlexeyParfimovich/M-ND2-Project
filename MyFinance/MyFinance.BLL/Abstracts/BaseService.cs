using MyFinance.DAL;

namespace MyFinance.BLL.Abstracts
{
    public abstract class BaseService
    {
        protected readonly IFinanceDbContext _db;

        public BaseService(IFinanceDbContext database)
        {
            _db = database;
        }
    }
}
