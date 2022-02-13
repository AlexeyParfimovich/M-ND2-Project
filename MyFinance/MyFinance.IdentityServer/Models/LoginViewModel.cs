using System.ComponentModel.DataAnnotations;

namespace MyFinance.IdentityServer.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The User name is required")]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //[Required]
        public string ReturnUrl { get; set; }
    }
}
