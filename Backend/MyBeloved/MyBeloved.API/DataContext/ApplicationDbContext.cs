using Microsoft.EntityFrameworkCore;
using MyBeloved.API.Models;

namespace MyBeloved.API.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Notebook> Notebooks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Page> Pages { get; set; }

    }
}
