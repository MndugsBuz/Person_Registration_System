using Microsoft.EntityFrameworkCore;
using Person_Registration_System.Database.Entities;

namespace Person_Registration_System.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<PersonInfo> Persons { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
