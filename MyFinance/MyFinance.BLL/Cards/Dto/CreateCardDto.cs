using MyFinance.BLL.Common.Abstracts;
using Newtonsoft.Json;
using System;

namespace MyFinance.BLL.Cards.Dto
{
    public class CreateCardDto: BaseDto
    {
        [JsonProperty("name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("validThru", Order = 2, Required = Required.Default)]
        public DateTime? ValidThru { get; set; }

        [JsonProperty("accountId", Order = 3, Required = Required.Default)]
        public long AccountId { get; set; }

        [JsonIgnore]
        public Guid BudgetId { get; set; }
    }
}
