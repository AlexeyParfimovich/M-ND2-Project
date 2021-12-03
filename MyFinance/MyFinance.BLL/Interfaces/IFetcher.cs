using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFinance.BLL.Interfaces
{
    public interface IFetcher<TKey, TEntityDto>
    {
        Task<IEnumerable<TEntityDto>> FetchAll();
        Task<TEntityDto> FetchByKey(TKey key);
    }
}
