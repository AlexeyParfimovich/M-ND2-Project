using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MyFinance.DAL.Entities
{
    public class BudgetEntity: BaseEntity
    {
        [JsonProperty("id", Order = 0, Required = Required.Default)]
        public Guid Id { get; set; }

        [JsonProperty("name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("balance", Order = 2, Required = Required.Default)]
        public decimal Balance { get; set; }

        [JsonProperty("UserId", Order = 3, Required = Required.Always)]
        public Guid UserId { get; set; }

        public UserEntity User { get; set; }

        [JsonProperty("currencyId", Order = 4, Required = Required.Always)]
        public string CurrencyId { get; set; }

        public CurrencyEntity Currency { get; set; }

        public ICollection<AccountEntity> Accounts { get; set; }
    }
}
