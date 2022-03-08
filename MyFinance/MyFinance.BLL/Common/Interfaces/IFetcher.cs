using MyFinance.BLL.Common.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFinance.BLL.Common.Interfaces
{
    public interface IFetcher<TEntity, TDto>
    {
        Task<TDto> FetchFirst(QueryFilter filter);

        Task<IEnumerable<TDto>> FetchFiltered(QueryFilter filter);
    }
}
