using System.Threading.Tasks;

namespace MyFinance.BLL.Interfaces
{
    public interface ICreator<TCreateDto, TEntityDto>
    {
        Task<TEntityDto> Create(TCreateDto dto);
    }
}
