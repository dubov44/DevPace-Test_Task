using DevPace.Domain.Models;
using DevPace.EntityFramework.Seed;
using Microsoft.EntityFrameworkCore;

namespace DevPace.EntityFramework
{
    public class DevPaceDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DevPaceDbContext(DbContextOptions options) : base(options)
        {
            Database?.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.Id)
                .HasName("PrimaryKey_CustomerId");

            base.OnModelCreating(modelBuilder);

            ContextSeed.DbSeed(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.DefaultTypeMapping<CustomerSearch>();
        }
    }
}
