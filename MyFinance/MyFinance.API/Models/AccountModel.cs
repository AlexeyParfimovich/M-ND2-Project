using System.Runtime.Serialization;

namespace MyFinance.API.Models
{
    [DataContract()]
    public class AccountModel
    {
        [DataMember(Name = "id", Order = 0, IsRequired = true)]
        public long Id { get; set; }

        [DataMember(Name = "name", Order = 1, IsRequired = true)]
        public string Name { get; set; }

        [DataMember(Name = "balance", Order = 2, EmitDefaultValue = false)]
        public decimal Balance { get; set; }

        [DataMember(Name = "budgetId", Order = 3, IsRequired = true)]
        public long BudgetId { get; set; }

        [DataMember(Name = "currencyId", Order = 4, IsRequired = true)]
        public string CurrencyId { get; set; }

        [DataMember(Name = "lastTransaction", Order = 5, EmitDefaultValue = false)]
        public ulong? LastTransaction { get; set; }
    }
}
