using System.Threading.Tasks;

namespace MyFinance.BLL.Interfaces
{
    public interface IRemover<TKey>
    {
        Task Remove(TKey key);
    }
}
