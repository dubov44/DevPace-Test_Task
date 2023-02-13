using Microsoft.Extensions.DependencyInjection;
using DevPace.WebApi.Client.Config;
using DevPace.WebApi.Client.HttpServices.Entities;
using DevPace.WebApi.Client.HttpServices.Interfaces;

namespace DevPace.Infrastructure
{
    public static class ApiConfiguration
    {
        public static void ApiServicesConfiguration(this IServiceCollection services, string baseAddress)
        {
            services.AddScoped<ICustomerHttpService, CustomerHttpService>();
            services.AddHttpClient(ClientNameConfig.CustomerClientName, httpClient =>
            {
                httpClient.BaseAddress = new Uri(baseAddress);
            });
        }
    }
}
