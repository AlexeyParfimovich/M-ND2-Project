using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyFinance.DAL.Entities
{
    public class CurrencyEntity: BaseTypedEntity<string>
    {
        [JsonProperty("name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("isMainCurrency", Order = 2, Required = Required.Default)]
        public bool IsMainCurrency { get; set; }

        [JsonProperty("exchangeRate", Order = 3, Required = Required.Default)]
        public decimal ExchangeRate { get; set; }

        [JsonIgnore]
        public ICollection<BudgetEntity> Budgets { get; set; }

        [JsonIgnore]
        public ICollection<AccountEntity> Accounts { get; set; }
    }
}
