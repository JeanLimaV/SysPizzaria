using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using SysPizzaria.Domain.Entities;

namespace SysPizzaria.Infra.Data.Context
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options) {}

        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci")
                .UseGuidCollation(string.Empty);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseDbContext).Assembly);
            modelBuilder.Ignore<ValidationResult>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
