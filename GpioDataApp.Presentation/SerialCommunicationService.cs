using GpioDataApp.GpioDataApp.Business.Interfaces;
using GpioDataApp.GpioDataApp.Communication.Interfaces;

namespace GpioDataApp.GpioDataApp.Presentation
{
    public class SerialCommunicationService
    {
        private readonly ISerialPortManager _serialPortManager;
        private readonly IDoorService _doorService;
        public SerialCommunicationService(ISerialPortManager serialPortManager,IDoorService doorService)
        {
            _serialPortManager = serialPortManager;
            _doorService = doorService;
        }

        public async Task StartCommunication()
        {
            Console.WriteLine("Serial port communication testing started!");

            try
            {
                _serialPortManager.OpenPort();
                _doorService.MonitorDoorStatus((status) =>
                {
                    _serialPortManager.SendMessageAsync(status);
                    Console.WriteLine(status);
                });

                while (true)
                {
                    Console.WriteLine("Please write the message (type 'exit' to quit)::");
                    string message = Console.ReadLine();

                    if (message.ToLower() == "exit")
                    {
                        break;
                    }

                    if (!string.IsNullOrEmpty(message))
                    {
                        await _serialPortManager.SendMessageAsync(message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                _serialPortManager.ClosePort();
                Console.WriteLine("Serial port closed.");
            }
        }
    }
}
