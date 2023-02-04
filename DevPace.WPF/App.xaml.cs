using System;
using System.Windows;
using DevPace.WPF.DependencyProvider;
using Microsoft.Extensions.DependencyInjection;
using DevPace.Infrastructure;
using DevPace.WPF.Infrastructure.Configurations;

namespace DevPace.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.DataAccessServicesConfiguration();
            services.BusinessLogicServicesConfiguration();
            services.WPFServicesConfiguration();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            DependencyResolver.ServiceProvider = services.BuildServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            Window window = DependencyResolver.GetService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }
    }
}
