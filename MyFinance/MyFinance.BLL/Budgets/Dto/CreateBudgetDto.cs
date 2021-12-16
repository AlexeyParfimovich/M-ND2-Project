using MyFinance.BLL.Common.Abstracts;
using Newtonsoft.Json;

namespace MyFinance.BLL.Budgets.Dto
{
    public class CreateBudgetDto: BaseDto
    {
        [JsonProperty("name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("currencyId", Order = 3, Required = Required.Always)]
        public string CurrencyId { get; set; }
    }
}
