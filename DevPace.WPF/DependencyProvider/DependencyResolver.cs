using System;
using Microsoft.Extensions.DependencyInjection;

namespace DevPace.WPF.DependencyProvider
{
    public static class DependencyResolver
    {
        public static IServiceProvider ServiceProvider;

        public static T GetService<T>()
        {
            return ServiceProvider.GetRequiredService<T>();
        }
    }
}
