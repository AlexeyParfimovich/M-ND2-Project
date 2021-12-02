using System.Threading.Tasks;

namespace MyFinance.BLL.Interfaces
{
    public interface IValidator<T>
    {
        Task Validate(T dto);
    }
}
