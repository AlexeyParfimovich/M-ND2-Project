using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace MyFinance.API.Models
{
    [DataContract()]
    public class UpdateAccountModel
    {
        [FromBody]
        [JsonProperty("id", Order = 0, Required = Required.Always)]
        public long Id { get; set; }

        [FromBody]
        [JsonProperty("name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [FromRoute]
        [JsonProperty("budgetId", Order = 3, Required = Required.Always)]
        public Guid BudgetId { get; set; }

        [FromBody]
        [JsonProperty("currencyId", Order = 4, Required = Required.Always)]
        public string CurrencyId { get; set; }
    }
}
