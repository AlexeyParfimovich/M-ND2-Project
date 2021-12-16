using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyFinance.DAL.Entities
{
    public class BudgetEntity: BaseTypedEntity<long>
    {
        [JsonProperty("name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("balance", Order = 2, Required = Required.Default)]
        public decimal Balance { get; set; }

        [JsonProperty("currencyId", Order = 3, Required = Required.Always)]
        public string CurrencyId { get; set; }

        public CurrencyEntity Currency { get; set; }

        public ICollection<AccountEntity> Accounts { get; set; }
    }
}
