using System.ComponentModel.DataAnnotations;

namespace MyFinance.IdentityServer.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The User name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The Password is required")]
        public string Password { get; set; }

        [Required]
        public string ReturnUrl { get; set; }
    }
}
