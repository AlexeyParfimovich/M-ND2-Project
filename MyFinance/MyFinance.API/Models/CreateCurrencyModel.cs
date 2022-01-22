using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MyFinance.API.Models
{
    [DataContract()]
    public class CreateCurrencyModel
    {
        [DataMember(Name = "id", Order = 0, IsRequired = true)]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Value length must be 3")]
        public string Id { get; set; }

        [DataMember(Name = "name", Order = 1, IsRequired = true)]
        [StringLength(256, MinimumLength = 1, ErrorMessage = "Value length out of range")]
        public string Name { get; set; }

        //[DataMember(Name = "exchangeRate", Order = 2, IsRequired = false)]
        //public decimal ExchangeRate { get; set; }
    }
}
