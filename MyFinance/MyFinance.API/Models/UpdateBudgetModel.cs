#nullable enable
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MyFinance.API.Models
{
    public class UpdateBudgetModel
    {
        [FromRoute]
        [JsonProperty("id", Order = 0, Required = Required.Always)]
        public long Id { get; set; }

        [FromBody]
        [JsonProperty("name", Order = 1, Required = Required.Always)]
        public string? Name { get; set; }

        [FromBody]
        [JsonProperty("balance", Order = 2, Required = Required.Default)]
        public decimal Balance { get; set; }

        [FromBody]
        [JsonProperty("currencyId", Order = 3, Required = Required.Always)]
        public string? CurrencyId { get; set; }
    }
}
