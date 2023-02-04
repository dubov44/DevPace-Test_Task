using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DevPace.EntityFramework
{
    public class DevPaceDbContextOptionsFactory : IDesignTimeDbContextFactory<DevPaceDbContext>
    {
        public DevPaceDbContext CreateDbContext(string[]? args = null)
        {
            var options = new DbContextOptionsBuilder<DevPaceDbContext>();

            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DevPaceDB;Trusted_Connection=True;");

            return new DevPaceDbContext(options.Options);
        }
    }
}
