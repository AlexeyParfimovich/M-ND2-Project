using MyFinance.BLL.Common.Abstracts;

namespace MyFinance.BLL.Currencies.Dto
{
    public class CurrencyDto: BaseDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal ExchangeRate { get; set; }
    }
}
