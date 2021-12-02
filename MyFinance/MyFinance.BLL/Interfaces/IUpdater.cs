using System.Threading.Tasks;

namespace MyFinance.BLL.Interfaces
{
    public interface IUpdater<TUpdateDto, TEntityDto>
    {
        Task<TEntityDto> Update(TUpdateDto dto);
    }
}
