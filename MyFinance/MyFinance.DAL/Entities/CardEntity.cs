using System;

namespace MyFinance.DAL.Entities
{
    public class CardEntity: BaseTypedEntity<string>
    {
        public DateTime? ValidThru { get; set; }

        public long AccountId { get; set; }
        public AccountEntity Account { get; set; }

        public ulong? LastTransaction { get; set; }

    }
}
