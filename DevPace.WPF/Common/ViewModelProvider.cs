using DevPace.WPF.DependencyProvider;
using DevPace.WPF.ViewModels;

namespace DevPace.WPF.Common
{
    public class ViewModelProvider
    {
        public CustomerListViewModel CustomerList => DependencyResolver.GetService<CustomerListViewModel>();

        public CustomerDetailsViewModel CustomerDetails => DependencyResolver.GetService<CustomerDetailsViewModel>();
    }
}
