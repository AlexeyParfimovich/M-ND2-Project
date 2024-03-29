﻿using Newtonsoft.Json;
using System;

namespace MyFinance.API.Models
{
    public class AccountModel
    {
        [JsonProperty("id", Order = 0, Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("balance", Order = 2, Required = Required.Default)]
        public decimal Balance { get; set; }

        [JsonProperty("budgetId", Order = 3, Required = Required.Always)]
        public Guid BudgetId { get; set; }

        [JsonProperty("currencyId", Order = 4, Required = Required.Always)]
        public string CurrencyId { get; set; }

        [JsonProperty("lastTransaction", Order = 5, Required = Required.Default)]
        public ulong? LastTransaction { get; set; }
    }
}
