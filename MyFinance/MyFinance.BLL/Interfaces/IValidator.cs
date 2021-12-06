using System.Threading.Tasks;

namespace MyFinance.BLL.Interfaces
{
    public interface IValidator<TDto>
    {
        Task<Task> Validate(TDto dto);
    }
}
