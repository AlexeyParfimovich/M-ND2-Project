using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MyFinance.DAL.Entities
{
    public class UserEntity: BaseEntity
    {
        [JsonProperty("id", Order = 0, Required = Required.Always)]
        public Guid Id { get; set; }

        [JsonProperty("name", Order = 1, Required = Required.Always)]
        public string UserName { get; set; }

        [JsonProperty("name", Order = 2, Required = Required.Default)]
        public string FirstName { get; set; }

        [JsonProperty("name", Order = 3, Required = Required.Default)]
        public string LastName { get; set; }

        [JsonProperty("name", Order = 4, Required = Required.Always)]
        public string Email { get; set; }

        public ICollection<BudgetEntity> Budgets { get; set; }
    }
}
