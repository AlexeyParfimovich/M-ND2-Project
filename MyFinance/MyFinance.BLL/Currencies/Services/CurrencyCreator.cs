using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.BLL.Currencies.Dto;

namespace MyFinance.BLL.Currencies.Services
{
    public class CurrencyCreator : BaseCreateService<CurrencyEntity, FetchCurrencyDto, CreateCurrencyDto>, ICreator<CurrencyEntity, FetchCurrencyDto, CreateCurrencyDto>
    {
        public CurrencyCreator(
            IFinanceDbContext database,
            IValidator<CreateCurrencyDto> validator) : base(database, validator)
        {}
    }
}
