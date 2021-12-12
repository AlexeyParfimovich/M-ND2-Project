using MyFinance.BLL.Currencies.Dto;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.DAL.Entities;

namespace MyFinance.BLL.Currencies.Services
{
    public class CurrencyCreateMapper : IDtoPartialMapper<CurrencyEntity, CurrencyDto, CreateCurrencyDto>
    {
        public CurrencyDto EntityToDto(CurrencyEntity entity)
        {
            return new CurrencyDto
            {
                Id = entity.Id,
                Name = entity.Name,
                ExchangeRate = entity.ExchangeRate,
            };
        }

        public CurrencyEntity DtoToEntity(CreateCurrencyDto dto)
        {
            return new CurrencyEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                ExchangeRate = dto.ExchangeRate,
            };
        }
    }
}
