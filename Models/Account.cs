using System.ComponentModel.DataAnnotations;

namespace AuthenticationService.Models
{
    public class AccountR
    {
        [StringLength(32, MinimumLength = 3), Required]
        public string Username {get;set;}
        [StringLength(32, MinimumLength = 8), Required]
        public string Password{get;set;}
        [Required]
        public string Role{get;set;}

    }
}