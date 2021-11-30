using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.DAL.Entities
{
    public class CurrencyEntity: BaseEntity
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public bool IsBase { get; set; }
        public decimal ExchangeRate { get; set; }

        public ICollection<BudgetEntity> Budgets { get; set; }
        public ICollection<AccountEntity> Accounts { get; set; }
    }
}
