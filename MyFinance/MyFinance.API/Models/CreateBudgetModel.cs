using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MyFinance.API.Models
{
    //[DataContract()]
    public class CreateBudgetModel
    {
        [JsonProperty("name", Order = 1, Required = Required.Always)]
        //[StringLength(256, MinimumLength = 1, ErrorMessage = "Value length out of range")]
        public string Name { get; set; }

        [JsonProperty("currencyId", Order = 3, Required = Required.Always)]
        //[StringLength(3, MinimumLength = 3, ErrorMessage = "Value length must be 3")]
        public string CurrencyId { get; set; }
    }
}
