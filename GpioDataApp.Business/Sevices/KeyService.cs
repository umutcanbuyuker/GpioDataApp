using GpioDataApp.GpioDataApp.Business.Interfaces;
using System.Device.Gpio;

namespace GpioDataApp.GpioDataApp.Business.Sevices
{
    public class KeyService : IKeyService
    {
        private readonly int _keyPin = 18;
        private readonly GpioController _controller;
        private bool _keyOn = false;
        public KeyService(GpioController controller)
        {
            _controller = controller;
            _controller.OpenPin(_keyPin, PinMode.InputPullUp);
            Console.WriteLine("Please start the key monitoring");
        }
        public void MonitorKeyStatus(Action<string> keyStatusChanged)
        {
            Task.Run(async () =>
            {
                {
                    while (true)
                    {
                        if (_controller.Read(_keyPin) == PinValue.Low)
                        {
                            _keyOn = !_keyOn;
                            string status = _keyOn ? "Anahtar Açık" : "Anahtar Kapalı";
                            keyStatusChanged(status);
                            await Task.Delay(500);
                        }
                        await Task.Delay(100);
                    }
                }
            });
        }
    }
}
