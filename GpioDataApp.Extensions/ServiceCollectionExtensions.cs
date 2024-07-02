using GpioDataApp.GpioDataApp.Registers;
using Microsoft.Extensions.DependencyInjection;
using System.Device.Gpio;

namespace GpioDataApp.GpioDataApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddSingleton<GpioController>();
            services.AddBusinessServices();
            services.AddCommunicationServices();

            return services;
        }
    }
}
