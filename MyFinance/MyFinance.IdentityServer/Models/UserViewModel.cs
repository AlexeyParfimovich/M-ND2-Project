using System.ComponentModel.DataAnnotations;

namespace MyFinance.IdentityServer.Models
{
    public class UserViewModel
    {
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
