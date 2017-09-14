using AuthenticationService.Models;
using System.Diagnostics.Contracts;

namespace AuthenticationService.Common.Extensions
{
    public static class AccountExtensions
    {
        public static AccountSettings ToAccountSettings(this Account input)
        {
            Contract.Requires(input != null);
            return new AccountSettings(){
                Name = input.UserName,
                Role = input.Role.Name
            };
        }

        public static AccountView ToAccountView(this Account input)
        {
            Contract.Requires(input != null);
            return new AccountView(){
                Name = input.UserName,
                Role = input.Role.Name,
                Id = input.Id
            };
        }
    }
}