using MyFinance.BLL.Abstracts;

namespace MyFinance.BLL.Budgets.Dto
{
    public class CreateBudgetDto: BaseDto
    {
        public string Name { get; set; }
        public string CurrencyType { get; set; }
    }
}
