using GpioDataApp.GpioDataApp.Business.Interfaces;
using GpioDataApp.GpioDataApp.Business.Sevices;
using Microsoft.Extensions.DependencyInjection;

namespace GpioDataApp.GpioDataApp.Registers
{
    public static class BusinessRegister
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddSingleton<IDoorService, DoorService>();
            services.AddSingleton<IKeyService, KeyService>();
            return services;
        }
    }
}
