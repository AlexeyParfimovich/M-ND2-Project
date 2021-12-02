using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.BLL.Budgets.Dto
{
    public class BudgetDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string CurrencyType { get; set; }
    }
}
