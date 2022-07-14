using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace MyFinance.API.Models
{
    [DataContract()]
    public class CreateAccountModel
    {
        [FromBody]
        [JsonProperty("name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [FromBody]
        [JsonProperty("currencyId", Order = 4, Required = Required.Always)]
        public string CurrencyId { get; set; }
    }
}
