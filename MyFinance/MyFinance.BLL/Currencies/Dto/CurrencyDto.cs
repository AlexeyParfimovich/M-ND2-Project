using MyFinance.BLL.Common.Abstracts;
using Newtonsoft.Json;

namespace MyFinance.BLL.Currencies.Dto
{
    public class CurrencyDto: BaseDto
    {
        [JsonProperty("id", Order = 0, Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("isMainCurrency", Order = 2, Required = Required.Default)]
        public bool IsMainCurrency { get; set; }

        [JsonProperty("exchangeRate", Order = 3, Required = Required.Default)]
        public decimal ExchangeRate { get; set; }
    }
}
