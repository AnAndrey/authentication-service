using AuthenticationService.Models;
using System.Diagnostics.Contracts;


namespace AuthenticationService.Common.Extensions
{
    public static class AccountSettingsExtensions
    {
        public static Account ToAccount(this AccountSettings input)
        {
            Contract.Requires(input != null);
            return new Account(){
                UserName = input.Name,
                Role = new Role(){Name = input.Role}
            };
        }
    }
}