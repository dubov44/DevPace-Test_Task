using Microsoft.EntityFrameworkCore;
using DevPace.Domain.Models;

namespace DevPace.EntityFramework.Seed
{
    public static class ContextSeed
    {
        public static void DbSeed(ModelBuilder modelBuilder)
        {
            var customers = new Customer[100];
            for (int i = 0; i < customers.Length; i++)
            {
                customers[i] = new Customer
                {
                    Id = i + 1,
                    Name = $"Name {i + 1}",
                    CompanyName = $"Company {i + 1}",
                    Email = $"email{i + 1}@mail.com",
                    Phone = $"{i + 1}"
                };
            }

            modelBuilder.Entity<Customer>().HasData(customers);
        }
    }
}
