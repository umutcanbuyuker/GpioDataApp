using GpioDataApp.GpioDataApp.Communication.Interfaces;
using System.IO.Ports;
using System.Text;

namespace GpioDataApp.GpioDataApp.Business.Sevices
{
    public class SerialPortManager : ISerialPortManager
    {
        private readonly SerialPort _serialPort;
        public SerialPortManager()
        {
            string portName = "/dev/ttyS0";
            int baudRate = 9600;
            _serialPort = new SerialPort(portName, baudRate)
            {
                Parity = Parity.None,
                StopBits = StopBits.One,
                DataBits = 8,
                Handshake = Handshake.None,
                ReadTimeout = 500,
                WriteTimeout = 500,
                Encoding = Encoding.UTF8
            };
        }
        public void ClosePort()
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
        }

        public void OpenPort()
        {
            if (!_serialPort.IsOpen)
            {
                _serialPort.Open();
                Console.WriteLine("Serial port opened successfully.");
            }
        }

        public async Task SendMessageAsync(string message)
        {
            try
            {
                _serialPort.WriteLine(message);
                _serialPort.Write("test");
                Console.WriteLine("Message sent: " + message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Access to the port is denied: " + ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("An I/O error occurred: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred:: " + ex.Message);
            }
        }
    }
}
