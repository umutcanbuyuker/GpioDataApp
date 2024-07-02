using GpioDataApp.GpioDataApp.Business.Sevices;
using GpioDataApp.GpioDataApp.Communication.Interfaces;
using GpioDataApp.GpioDataApp.Presentation;
using Microsoft.Extensions.DependencyInjection;

namespace GpioDataApp.GpioDataApp.Registers
{
    public static class CommunicationRegister
    {
        public static IServiceCollection AddCommunicationServices(this IServiceCollection services)
        {
            services.AddSingleton<ISerialPortManager, SerialPortManager>();
            services.AddSingleton<SerialCommunicationService>();
            return services;
        }
    }
}
