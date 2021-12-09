using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFinance.BLL.Interfaces
{
    public interface IFetcher<TEntity, TKey, TDto>
    {
        Task<IEnumerable<TDto>> FetchAll();
        Task<TDto> FetchByKey(TKey key);
    }
}
