using MyFinance.BLL.Common.Abstracts;

namespace MyFinance.BLL.Accounts.Dto
{
    public class CreateAccountDto: BaseDto
    {
        public string Name { get; set; }
        public long BudgetId { get; set; }
        public string CurrencyId { get; set; }
    }
}
