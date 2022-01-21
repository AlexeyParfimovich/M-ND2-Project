using MyFinance.BLL.Common.Abstracts;
using Newtonsoft.Json;
using System;

namespace MyFinance.BLL.Budgets.Dto
{
    public class FetchBudgetDto: BaseDto
    {
        [JsonProperty("id", Order = 0, Required = Required.Always)]
        public Guid Id { get; set; }

        [JsonProperty("name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("balance", Order = 2, Required = Required.Default)]
        public decimal Balance { get; set; }

        [JsonProperty("currencyId", Order = 4, Required = Required.Always)]
        public string CurrencyId { get; set; }
    }
}
