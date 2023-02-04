using DevPace.WPF.Common;
using DevPace.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace DevPace.WPF.Infrastructure.Configurations
{
    public static class WPFConfigurations
    {
        public static void WPFServicesConfiguration(this IServiceCollection services)
        {
            services.AddTransient<CustomerListViewModel>();
            services.AddTransient<CustomerDetailsViewModel>();
            services.AddTransient<MainViewModel>();
            services.AddScoped(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });
            services.AddSingleton<DynamicParameters>();
        }
    }
}
