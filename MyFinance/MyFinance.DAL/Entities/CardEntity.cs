using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.DAL.Entities
{
    public class CardEntity: BaseEntity
    {
        public string Name { get; set; }
        public DateTime? ValidThru { get; set; }

        public long AccountId { get; set; }
        public AccountEntity Account { get; set; }

        public ulong? LastTransaction { get; set; }

    }
}
