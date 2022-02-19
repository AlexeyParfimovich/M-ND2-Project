using System.ComponentModel.DataAnnotations;

namespace MyFinance.IdentityServer.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The User name is required")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
