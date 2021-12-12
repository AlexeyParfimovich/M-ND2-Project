using MyFinance.BLL.Common.Abstracts;

namespace MyFinance.BLL.Accounts.Dto
{
    public class AccountDto: BaseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public long BudgetId { get; set; }
        public string CurrencyId { get; set; }
        public ulong? LastTransaction { get; set; }
    }
}
