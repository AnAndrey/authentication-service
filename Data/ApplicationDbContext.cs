using Microsoft.EntityFrameworkCore;
using AuthenticationService.Models;
namespace AuthenticationService.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
    }
}