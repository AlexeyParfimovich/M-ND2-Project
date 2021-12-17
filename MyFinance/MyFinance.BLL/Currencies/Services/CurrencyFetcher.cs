using MyFinance.DAL;
using MyFinance.DAL.Entities;
using MyFinance.BLL.Common.Abstracts;
using MyFinance.BLL.Common.Interfaces;
using MyFinance.BLL.Currencies.Dto;

namespace MyFinance.BLL.Currencies.Services
{
    public class CurrencyFetcher : BaseFetchService<CurrencyEntity, string, CurrencyDto>, IFetcher<CurrencyEntity, string, CurrencyDto>
    {
        public CurrencyFetcher(
            IFinanceDbContext database,
            IContractMapper mapper) : base (database, mapper)
        {
        }
    }
}
