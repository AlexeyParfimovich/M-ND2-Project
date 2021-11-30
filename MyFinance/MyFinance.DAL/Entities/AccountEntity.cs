using System;
using System.Collections.Generic;

namespace MyFinance.DAL.Entities
{
    public class AccountEntity: BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public long BudgetId { get; set; }
        public BudgetEntity Budget { get; set; }

        public string CurrencyType { get; set; }
        public CurrencyEntity Currency { get; set; }

        public ICollection<CardEntity> Cards { get; set; }

        public ulong? LastTransaction { get; set; }

    }
}
