using MyFinance.DAL.Entities;

namespace MyFinance.BLL.Interfaces
{
    public interface IDtoMapper<TEntity, TDto> where TEntity: BaseEntity
    {
        public TDto EntityToDto(TEntity entity);
    }
}
