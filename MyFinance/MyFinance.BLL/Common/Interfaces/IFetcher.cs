using MyFinance.BLL.Common.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFinance.BLL.Common.Interfaces
{
    public interface IFetcher<TEntity, TDto>
    {
        Task<IEnumerable<TDto>> FetchByFilter(QueryFilter filter);
    }
}
