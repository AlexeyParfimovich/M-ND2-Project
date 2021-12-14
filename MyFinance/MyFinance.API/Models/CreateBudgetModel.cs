﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MyFinance.API.Models
{
    [DataContract()]
    public class CreateBudgetModel
    {
        [DataMember(Name = "name", Order = 1, IsRequired = true)]
        [StringLength(256, MinimumLength = 1, ErrorMessage = "Value length out of range")]
        public string Name { get; set; }

        [DataMember(Name = "currencyId", Order = 3, IsRequired = true)]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Value length must be 3")]
        public string CurrencyId { get; set; }
    }
}