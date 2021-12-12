using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MyFinance.API.Models
{
    [DataContract()]
    public class UpdateAccountModel
    {
        [DataMember(Name = "id", Order = 0, IsRequired = true)]
        [Range(1, long.MaxValue, ErrorMessage = "Value out of range")]
        public long Id { get; set; }

        [DataMember(Name = "name", Order = 1, IsRequired = false)]
        [StringLength(256, MinimumLength = 1, ErrorMessage = "Value length out of range")]
        public string Name { get; set; }

        [DataMember(Name = "budgetId", Order = 3, IsRequired = false)]
        [Range(1, long.MaxValue, ErrorMessage = "Value out of range")]
        public long BudgetId { get; set; }

        [DataMember(Name = "currencyId", Order = 3, IsRequired = false)]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Value length must be 3")]
        public string CurrencyId { get; set; }
    }
}
