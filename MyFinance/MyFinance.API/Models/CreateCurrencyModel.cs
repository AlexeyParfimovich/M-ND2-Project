using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace MyFinance.API.Models
{
    [DataContract()]
    public class CreateCurrencyModel
    {
        [FromBody]
        [JsonProperty("id", Order = 0, Required = Required.Always)]
        public string Id { get; set; }

        [FromBody]
        [JsonProperty("name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [FromBody]
        [JsonProperty("isMainCurrency", Order = 2, Required = Required.Default)]
        public bool IsMainCurrency { get; set; }

        [FromBody]
        [JsonProperty("exchangeRate", Order = 3, Required = Required.Default)]
        public decimal ExchangeRate { get; set; }
    }
}
