using System.Collections.Generic;

namespace AuthenticationService.Models
{
    public class Role
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public List<Account> Accounts { get; set; }
    }
}