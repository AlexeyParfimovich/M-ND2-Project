using Newtonsoft.Json;
using System;

namespace MyFinance.API.Models
{
    public class CardModel
    {
        [JsonProperty("id", Order = 0, Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("validThru", Order = 2, Required = Required.Default)]
        public DateTime? ValidThru { get; set; }

        [JsonProperty("accountId", Order = 3, Required = Required.Always)]
        public long AccountId { get; set; }

        [JsonProperty("lastTransaction", Order = 4, Required = Required.Default)]
        public ulong? LastTransaction { get; set; }
    }
}
