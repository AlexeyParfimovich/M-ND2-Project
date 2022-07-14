using System.Threading.Tasks;

namespace MyFinance.BLL.Common.Interfaces
{
    public interface ICreator<TEntity, TDto, TPartialDto>
    {
        Task<TDto> Create(TPartialDto dto);
    }
}
