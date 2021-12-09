using System.Threading.Tasks;

namespace MyFinance.BLL.Interfaces
{
    public interface IUpdater<TEntity, TDto, TPartialDto>
    {
        Task<TDto> Update(TPartialDto dto);
    }
}
