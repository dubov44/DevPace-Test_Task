using DevPace.BusinessLogic.Services.Entities;
using DevPace.BusinessLogic.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DevPace.Infrastructure
{
    public static class BusinessLogicConfigurations
    {
        public static void BusinessLogicServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
