using MyFinance.BLL.Abstracts;

namespace MyFinance.BLL.Budgets.Dto
{
    public class UpdateBudgetDto: BaseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CurrencyId { get; set; }
    }
}
