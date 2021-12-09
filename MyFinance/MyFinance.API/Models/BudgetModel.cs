namespace MyFinance.API.Models
{
    public class BudgetModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string CurrencyId { get; set; }
    }
}
