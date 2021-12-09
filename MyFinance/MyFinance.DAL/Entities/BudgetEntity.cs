using System.Collections.Generic;

namespace MyFinance.DAL.Entities
{
    public class BudgetEntity: BaseTypedEntity<long>
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public string CurrencyId { get; set; }
        public CurrencyEntity Currency { get; set; }

        public ICollection<AccountEntity> Accounts { get; set; }
    }
}
