using System.ComponentModel.DataAnnotations;

namespace MyFinance.IdentityServer.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "User name is required")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password mismatch")]
        public string PasswordConfirm { get; set; }

        public string Code { get; set; }
    }
}
