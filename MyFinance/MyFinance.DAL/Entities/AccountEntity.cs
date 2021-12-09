using System.Collections.Generic;

namespace MyFinance.DAL.Entities
{
    public class AccountEntity: BaseTypedEntity<long>
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public long BudgetId { get; set; }
        public BudgetEntity Budget { get; set; }

        public string CurrencyId { get; set; }
        public CurrencyEntity Currency { get; set; }

        public ICollection<CardEntity> Cards { get; set; }

        public ulong? LastTransaction { get; set; }

    }
}
