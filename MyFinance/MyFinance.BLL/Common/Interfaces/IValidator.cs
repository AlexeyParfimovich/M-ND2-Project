using System.Threading.Tasks;

namespace MyFinance.BLL.Common.Interfaces
{
    public interface IValidator<TDto>
    {
        Task<Task> Validate(TDto dto);
    }
}
