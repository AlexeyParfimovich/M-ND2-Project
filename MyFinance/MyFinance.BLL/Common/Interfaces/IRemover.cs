using MyFinance.BLL.Common.Infrastructure;
using System.Threading.Tasks;

namespace MyFinance.BLL.Common.Interfaces
{
    public interface IRemover<TEntity>
    {
        Task Remove(QueryFilter filter);
    }
}
