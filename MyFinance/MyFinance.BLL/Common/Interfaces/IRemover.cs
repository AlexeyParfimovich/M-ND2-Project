using System.Threading.Tasks;

namespace MyFinance.BLL.Common.Interfaces
{
    public interface IRemover<TEntity, TKey>
    {
        Task Remove(TKey key);
    }
}
