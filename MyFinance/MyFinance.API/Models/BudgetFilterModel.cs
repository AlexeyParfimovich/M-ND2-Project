#nullable enable
using Microsoft.AspNetCore.Mvc;
using MyFinance.BLL.Common.Abstracts;
using Newtonsoft.Json;

namespace MyFinance.API.Models
{
    public class BudgetFilterModel: BaseFilterDto
    {
        [FromQuery]
        [JsonProperty("id", Order = 0, Required = Required.Default)]
        public string[]? Id { get; set; }

        [FromQuery]
        [JsonProperty("name", Order = 1, Required = Required.Default)]
        public string[]? Name { get; set; }

        [FromQuery]
        [JsonProperty("balance", Order = 2, Required = Required.Default)]
        public string[]? Balance { get; set; }

        [FromQuery]
        [JsonProperty("currencyId", Order = 3, Required = Required.Default)]
        public string[]? CurrencyId { get; set; }
    }
}
