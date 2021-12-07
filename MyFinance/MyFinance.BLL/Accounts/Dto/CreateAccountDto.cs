using MyFinance.BLL.Abstracts;

namespace MyFinance.BLL.Accounts.Dto
{
    public class CreateAccountDto: BaseDto
    {
        public string Name { get; set; }
        public long BudgetId { get; set; }
        public string CurrencyType { get; set; }
    }
}
