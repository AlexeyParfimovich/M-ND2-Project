using System.Threading.Tasks;

namespace MyFinance.BLL.Interfaces
{
    public interface ICreator<TEntity, TDto, TPartialDto>
    {
        Task<TDto> Create(TPartialDto dto);
    }
}
