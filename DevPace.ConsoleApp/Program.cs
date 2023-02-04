using DevPace.Domain.Models;
using DevPace.Domain.Services;
using DevPace.EntityFramework;
using DevPace.EntityFramework.Services;

namespace DevPace.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDataService<Customer> customerService = new GenericDataService<Customer>(new DevPaceDbContextOptionsFactory());

            customerService.CreateAsync(new Customer()
            {
                CompanyName = "company name 1",
                Email = "email 1",
                Name = "name 1",
                Phone = "000"
            }).Wait();
        }
    }
}