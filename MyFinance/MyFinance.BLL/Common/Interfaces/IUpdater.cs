using System.Threading.Tasks;

namespace MyFinance.BLL.Common.Interfaces
{
    public interface IUpdater<TEntity, TDto, TPartialDto>
    {
        Task<TDto> Update(TPartialDto dto);
    }
}
