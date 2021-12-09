﻿using MyFinance.DAL.Entities;

namespace MyFinance.BLL.Interfaces
{
    public interface IDtoPartialMapper<TEntity, TDto, TPartialDto> where TEntity : BaseEntity
    {
        public TEntity DtoToEntity(TPartialDto dto);
        public TDto EntityToDto(TEntity entity);
    }
}
