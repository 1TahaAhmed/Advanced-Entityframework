using Advanced_Entityframework_Core_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace Advanced_Entityframework_Core_Task.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { 
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<Product>().HasIndex(p => p.Name);
        }
    }
}