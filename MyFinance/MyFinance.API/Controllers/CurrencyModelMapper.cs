using MyFinance.API.Models;
using MyFinance.BLL.Currencies.Dto;

namespace MyFinance.API.Controllers
{
    public static class CurrencyModelMapper
    {
        public static CreateCurrencyDto MapToDtoCreate(CreateCurrencyModel model)
        {
            return new CreateCurrencyDto
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public static UpdateCurrencyDto MapToDtoUpdate(UpdateCurrencyModel model)
        {
            return new UpdateCurrencyDto
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public static CurrencyModel MapToModel(CurrencyDto dto)
        {
            return new CurrencyModel
            {
                Id = dto.Id,
                Name = dto.Name,
            };
        }
    }
}
