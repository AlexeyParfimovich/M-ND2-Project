using System.ComponentModel.DataAnnotations;

namespace MyFinance.API.Models
{
    public class CreateBudgetModel
    {
        [Required(ErrorMessage = "Budget name is missed")]
        [DataType(DataType.Text, ErrorMessage = "Budget name must be a text value")]
        [StringLength(256, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Currency type is missed")]
        [DataType(DataType.Text, ErrorMessage = "Currency type must be a text value")]
        [StringLength(3, ErrorMessage = "Currency type length must be {3}")]
        public string CurrencyType { get; set; }
    }
}
