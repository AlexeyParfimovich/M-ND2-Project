using MyFinance.BLL.Common.Abstracts;

namespace MyFinance.BLL.Budgets.Dto
{
    public class CreateBudgetDto: BaseDto
    {
        public string Name { get; set; }
        public string CurrencyId { get; set; }
    }
}
