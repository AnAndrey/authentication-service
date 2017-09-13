using System.ComponentModel.DataAnnotations;

namespace AuthenticationService.Models
{
    public class AccountSettings
    {
        [StringLength(32, MinimumLength = 3), Required]
        public string Name {get;set;}
        [StringLength(32, MinimumLength = 8), Required]
        public string Password{get;set;}
        [Required]
        public string Role{get;set;}

    }
}