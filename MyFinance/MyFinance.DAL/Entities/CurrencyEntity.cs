using System.Collections.Generic;

namespace MyFinance.DAL.Entities
{
    public class CurrencyEntity: BaseTypedEntity<string>
    {
        public string Name { get; set; }
        public decimal ExchangeRate { get; set; }
        public ICollection<BudgetEntity> Budgets { get; set; }
        public ICollection<AccountEntity> Accounts { get; set; }
    }
}
