using System.Threading.Tasks;

namespace MyFinance.BLL.Interfaces
{
    public interface IRemover<TEntity, TKey>
    {
        Task Remove(TKey key);
    }
}
