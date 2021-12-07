using System.Threading.Tasks;
using MyFinance.BLL.Abstracts;

namespace MyFinance.BLL.Interfaces
{
    public interface IValidator<TDto>
    {
        Task<Task> Validate(TDto dto);
    }
}
