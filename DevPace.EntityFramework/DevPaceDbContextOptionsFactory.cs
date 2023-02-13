using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DevPace.EntityFramework
{
    public class DevPaceDbContextOptionsFactory : IDesignTimeDbContextFactory<DevPaceDbContext>
    {
        private readonly string connectionString;

        public DevPaceDbContextOptionsFactory(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public DevPaceDbContext CreateDbContext(string[]? args = null)
        {
            var options = new DbContextOptionsBuilder<DevPaceDbContext>();

            options.UseSqlServer(connectionString);

            return new DevPaceDbContext(options.Options);
        }
    }
}
