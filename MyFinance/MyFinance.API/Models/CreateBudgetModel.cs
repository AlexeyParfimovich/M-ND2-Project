﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace MyFinance.API.Models
{
    public class CreateBudgetModel
    {
        [FromBody]
        [JsonProperty("name", Order = 1, Required = Required.Always)]
        public string Name { get; set; }

        [FromBody]
        [JsonProperty("currencyId", Order = 4, Required = Required.Always)]
        public string CurrencyId { get; set; }
    }
}
