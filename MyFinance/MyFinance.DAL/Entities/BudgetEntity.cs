using System.Collections.Generic;

namespace MyFinance.DAL.Entities
{
    public class BudgetEntity: BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public string CurrencyType { get; set; }
        public CurrencyEntity Currency { get; set; }

        public ICollection<AccountEntity> Accounts { get; set; }
    }
}
