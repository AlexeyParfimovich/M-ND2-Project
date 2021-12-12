using System;
using System.Runtime.Serialization;

namespace MyFinance.API.Models
{
    [DataContract()]
    public class CardModel
    {
        [DataMember(Name = "id", Order = 0, IsRequired = true)]
        public string Id { get; set; }

        [DataMember(Name = "validThru", Order = 1, IsRequired = false)]
        public DateTime? ValidThru { get; set; }

        [DataMember(Name = "accountId", Order = 2, IsRequired = true)]
        public long AccountId { get; set; }

        [DataMember(Name = "lastTransaction", Order = 3, IsRequired = false)]
        public ulong? LastTransaction { get; set; }
    }
}
