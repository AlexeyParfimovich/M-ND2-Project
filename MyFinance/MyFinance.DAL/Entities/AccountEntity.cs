using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MyFinance.DAL.Entities
{
    public class AccountEntity: BaseEntity
    {
        [JsonProperty("id", Order = 0, Required = Required.Default)]
        public long Id { get; set; }

        [JsonProperty("name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("balance", Order = 2, Required = Required.Default)]
        public decimal Balance { get; set; }

        [JsonProperty("budgetId", Order = 3, Required = Required.Always)]
        public Guid BudgetId { get; set; }

        [JsonIgnore]
        public BudgetEntity Budget { get; set; }

        [JsonProperty("currencyId", Order = 4, Required = Required.Always)]
        public string CurrencyId { get; set; }

        [JsonIgnore]
        public CurrencyEntity Currency { get; set; }

        [JsonIgnore]
        public ICollection<CardEntity> Cards { get; set; }

        [JsonProperty("lastTransaction", Order = 5, Required = Required.Default)]
        public ulong? LastTransaction { get; set; }
    }
}
