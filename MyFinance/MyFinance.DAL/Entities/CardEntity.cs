using Newtonsoft.Json;
using System;

namespace MyFinance.DAL.Entities
{
    public class CardEntity: BaseTypedEntity<string>
    {
        [JsonProperty("validThru", Order = 1, Required = Required.Default)]
        public DateTime? ValidThru { get; set; }

        [JsonProperty("accountId", Order = 2, Required = Required.Always)]
        public long AccountId { get; set; }

        [JsonIgnore]
        public AccountEntity Account { get; set; }

        [JsonProperty("lastTransaction", Order = 3, Required = Required.Default)]
        public ulong? LastTransaction { get; set; }

    }
}
