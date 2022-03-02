using MyFinance.BLL.Common.Abstracts;
using Newtonsoft.Json;
using System;

namespace MyFinance.BLL.Accounts.Dto
{
    public class UpdateAccountDto: BaseDto
    {
        [JsonProperty("id", Order = 0, Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("name", Order = 1, Required = Required.Default)]
        public string Name { get; set; }

        [JsonProperty("budgetId", Order = 3, Required = Required.Always)]
        public Guid BudgetId { get; set; }

        [JsonProperty("currencyId", Order = 4, Required = Required.Default)]
        public string CurrencyId { get; set; }
    }
}
