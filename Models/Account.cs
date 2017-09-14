using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationService.Models
{
    public class Account:IdentityUser
    {
        //public int Id {get;set;}
        //public string Name {get;set;}
        //public string Password{get;set;}
        public Role Role{get;set;}
        public int? RoleId { get; set; }

    }
}