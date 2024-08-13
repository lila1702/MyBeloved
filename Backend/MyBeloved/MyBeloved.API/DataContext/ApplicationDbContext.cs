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
        //public DbSet<NotebookCategory> NotebooksCategories { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<NotebookCategory>().HasKey(nc => new { nc.NotebookId, nc.CategoryId });
        //    modelBuilder.Entity<NotebookCategory>().HasOne(nc => nc.Notebook).WithMany(n => n.NotebookCategories).HasForeignKey(nc => nc.CategoryId);
        //    modelBuilder.Entity<NotebookCategory>().HasOne(nc => nc.Category).WithMany(c => c.NotebookCategories).HasForeignKey(nc => nc.CategoryId);
        //}
    }
}
