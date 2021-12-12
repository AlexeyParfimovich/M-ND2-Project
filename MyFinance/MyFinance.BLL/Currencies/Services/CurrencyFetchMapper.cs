using MyFinance.BLL.Currencies.Dto;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.DAL.Entities;

namespace MyFinance.BLL.Currencies.Services
{
    public class CurrencyFetchMapper : IDtoMapper<CurrencyEntity, CurrencyDto>
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
    }
}
