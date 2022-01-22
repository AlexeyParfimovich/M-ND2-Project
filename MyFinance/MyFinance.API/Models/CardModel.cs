using Newtonsoft.Json;
using System;

namespace MyFinance.API.Models
{
    public class CardModel
    {
        [JsonProperty("id", Order = 0, Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("validThru", Order = 1, Required = Required.Default)]
        public DateTime? ValidThru { get; set; }

        [JsonProperty("accountId", Order = 2, Required = Required.Always)]
        public long AccountId { get; set; }

        [JsonProperty("lastTransaction", Order = 3, Required = Required.Default)]
        public ulong? LastTransaction { get; set; }
    }
}
