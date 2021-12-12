using System.Runtime.Serialization;

namespace MyFinance.API.Models
{
    [DataContract()]
    public class CurrencyModel
    {
        [DataMember(Name = "id", Order = 0, IsRequired = true)]
        public string Id { get; set; }

        [DataMember(Name = "name", Order = 1, IsRequired = true)]
        public string Name { get; set; }

        //[DataMember(Name = "exchangeRate", Order = 2, IsRequired = false)]
        //public decimal ExchangeRate { get; set; }
    }
}
