using MyFinance.DAL.Entities;

namespace MyFinance.BLL.Interfaces
{
    public interface IMapper<TEntity, TDto, TCreateDto, TUpdateDto> where TEntity: BaseEntity
    {
        public TEntity DtoToEntity(TCreateDto dto);

        public TEntity DtoToEntity(TUpdateDto dto);

        public TDto EntityToDto(TEntity entity);
    }
}
