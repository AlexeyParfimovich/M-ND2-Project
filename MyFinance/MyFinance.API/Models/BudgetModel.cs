﻿using Newtonsoft.Json;

namespace MyFinance.API.Models
{
    public class BudgetModel
    {
        [JsonProperty("id", Order = 0, Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("balance", Order = 2, Required = Required.Default)]
        public decimal Balance { get; set; }

        [JsonProperty("currency_id", Order = 3, Required = Required.Always)]
        public string CurrencyId { get; set; }
    }
}