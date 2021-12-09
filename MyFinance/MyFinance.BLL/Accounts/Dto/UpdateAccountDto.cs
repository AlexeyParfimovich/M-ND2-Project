using MyFinance.BLL.Abstracts;

namespace MyFinance.BLL.Accounts.Dto
{
    public class UpdateAccountDto: BaseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long BudgetId { get; set; }
        public string CurrencyId { get; set; }
    }
}
