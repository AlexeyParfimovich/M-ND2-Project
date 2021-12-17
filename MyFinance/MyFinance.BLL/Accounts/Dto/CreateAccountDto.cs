using MyFinance.BLL.Common.Abstracts;
using Newtonsoft.Json;

namespace MyFinance.BLL.Accounts.Dto
{
    public class CreateAccountDto: BaseDto
    {
        [JsonProperty("name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("budgetId", Order = 3, Required = Required.Always)]
        public long BudgetId { get; set; }

        [JsonProperty("currencyId", Order = 4, Required = Required.Always)]
        public string CurrencyId { get; set; }
    }
}
