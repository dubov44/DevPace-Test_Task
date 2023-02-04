using DevPace.Domain.Models;
using DevPace.Domain.Services;
using DevPace.EntityFramework;
using DevPace.EntityFramework.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DevPace.Infrastructure
{
    public static class DataAccessConfigurations
    {
        public static void DataAccessServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IDataService<Customer>, GenericDataService<Customer>>();
            services.AddScoped<ICustomerDataService, CustomerDataService>();
            services.AddScoped<DevPaceDbContextOptionsFactory>();
        }
    }
}
