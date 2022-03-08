using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace MyFinance.API.Models
{
    public class CreateCardModel
    {
        [FromBody]
        [JsonProperty("name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [FromBody]
        [JsonProperty("validThru", Order = 2, Required = Required.Default)]
        public DateTime? ValidThru { get; set; }

        [FromBody]
        [JsonProperty("accountId", Order = 3, Required = Required.Default)]
        public long AccountId { get; set; }
    }
}
