using MyFinance.BLL.Abstracts;

namespace MyFinance.BLL.Budgets.Dto
{
    public class BudgetDto: BaseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string CurrencyId { get; set; }
    }
}
