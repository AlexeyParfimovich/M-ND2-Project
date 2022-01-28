#nullable enable
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace MyFinance.API.Models
{
    public class UpdateBudgetModel
    {
        [FromBody]
        [JsonProperty("id", Order = 0, Required = Required.Always)]
        public Guid Id { get; set; }

        [FromBody]
        [JsonProperty("name", Order = 1, Required = Required.Always)]
        public string? Name { get; set; }

        [FromBody]
        [JsonProperty("currencyId", Order = 4, Required = Required.Always)]
        public string? CurrencyId { get; set; }
    }
}
