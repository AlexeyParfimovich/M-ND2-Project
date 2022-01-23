using System.ComponentModel.DataAnnotations;

namespace MyFinance.IdentityServer.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required]
        public string ReturnUrl { get; set; }
    }
}
