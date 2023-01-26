using Microsoft.EntityFrameworkCore;
using Person_Registration_System.Database.Entities;

namespace Person_Registration_System.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<PersonInfo> PersonsInfo { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
