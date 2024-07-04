using GpioDataApp.GpioDataApp.Business.Interfaces;
using System.Device.Gpio;

namespace GpioDataApp.GpioDataApp.Business.Sevices
{
    public class DoorService : IDoorService
    {
        private readonly int _pin = 16;
        private readonly GpioController _controller;
        private bool _doorOpen = false;
        public DoorService(GpioController controller)
        {
            _controller = controller;
            _controller.OpenPin(_pin, PinMode.InputPullUp);
            Console.WriteLine("Please start the button.");
        }
        public void MonitorDoorStatus(Action<string> doorStatusChanged)
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    if (_controller.Read(_pin) == PinValue.Low)
                    {
                        _doorOpen = !_doorOpen;
                        string status = _doorOpen ? "Kapi Acik" : "Kapi Kapali";
                        doorStatusChanged(status);
                        await Task.Delay(500); // debounce delay
                    }
                    await Task.Delay(100);
                }
            });
        }
    }
}
