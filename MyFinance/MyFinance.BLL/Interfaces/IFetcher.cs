using System.Threading.Tasks;

namespace MyFinance.BLL.Interfaces
{
    public interface IFetcher<TKey, TEntityDto>
    {
        Task<TEntityDto> GetByKey(TKey key);
    }
}
