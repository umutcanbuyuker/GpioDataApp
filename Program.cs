using GpioDataApp.GpioDataApp.Business.Interfaces;
using GpioDataApp.GpioDataApp.Business.Sevices;
using GpioDataApp.GpioDataApp.Communication.Interfaces;
using GpioDataApp.GpioDataApp.Presentation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GpioDataApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var serialCommunicationService = host.Services.GetRequiredService<SerialCommunicationService>();
            await serialCommunicationService.StartCommunication();
            await host.RunAsync();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IDoorService,DoorService>();
                    services.AddSingleton<ISerialPortManager, SerialPortManager>();
                    services.AddSingleton<IKeyService, KeyService>();
                    services.AddSingleton<SerialCommunicationService>();
                });

        #region V2
        //var host = Host.CreateDefaultBuilder(args)
        //   .ConfigureServices((context, services) =>
        //   {
        //       services.AddScoped<IButtonHandler, ButtonHandler>();
        //       services.AddScoped<IDoorService, DoorService>();
        //       services.AddScoped<IDoorDataSevice, DoorDataService>();
        //   })
        //   .Build();

        //using (var scope = host.Services.CreateScope())
        //{
        //    var services = scope.ServiceProvider;
        //    var buttonHandler = services.GetRequiredService<IButtonHandler>();
        //    await buttonHandler.StartButtonMonitoring();
        //}

        //await host.RunAsync();
        #endregion
        #region SeriportV1
        //Console.WriteLine("Button testing started!");
        //int pin = 16;
        //using var controller = new GpioController();
        //controller.OpenPin(pin, PinMode.InputPullUp);
        //Console.WriteLine("Please start the button.");

        //SerialPort serialPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
        //serialPort.Open();

        //while (true)
        //{
        //    if (controller.Read(pin) == PinValue.Low)
        //    {
        //        Console.WriteLine("Butona Basıldı!");
        //        serialPort.WriteLine("Serial Port Butona Basıldı");
        //        await Task.Delay(500);
        //    }
        //    await Task.Delay(100);
        //}
        #endregion
        #region Seriport Test Send Message
        //    Console.WriteLine("Serial port communication testing started!");

        //    string portName = "/dev/ttyS0"; 
        //    int baudRate = 9600; 

        //    using SerialPort serialPort = new SerialPort(portName, baudRate);

        //    try
        //    {
        //        if (!serialPort.IsOpen)
        //        {
        //            serialPort.Open();
        //            Console.WriteLine("Serial port opened successfully.");
        //        }

        //        while (true)
        //        {
        //            Console.WriteLine("Please write the message (type 'exit' to quit):");
        //            string message = Console.ReadLine();

        //            if (message.ToLower() == "exit")
        //            {
        //                break;
        //            }

        //            if (!string.IsNullOrEmpty(message))
        //            {
        //                SendMessageOverSerialPort(serialPort, message);
        //            }
        //        }
        //    }
        //    catch (UnauthorizedAccessException ex)
        //    {
        //        Console.WriteLine("Access to the port is denied: " + ex.Message);
        //    }
        //    catch (IOException ex)
        //    {
        //        Console.WriteLine("An I/O error occurred: " + ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("An unexpected error occurred: " + ex.Message);
        //    }
        //    finally
        //    {
        //        if (serialPort.IsOpen)
        //        {
        //            serialPort.Close();
        //            Console.WriteLine("Serial port closed.");
        //        }
        //    }
        //}

        //static void SendMessageOverSerialPort(SerialPort serialPort, string message)
        //{
        //    try
        //    {
        //        serialPort.WriteLine(message);
        //        Console.WriteLine("Message sent: " + message);
        //    }
        //    catch (UnauthorizedAccessException ex)
        //    {
        //        Console.WriteLine("Access to the port is denied: " + ex.Message);
        //    }
        //    catch (IOException ex)
        //    {
        //        Console.WriteLine("An I/O error occurred: " + ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("An unexpected error occurred: " + ex.Message);
        //    }

        #endregion
        #region Seriport Test Receive Message
        //    string portName = "COM3"; // Kullanmak istediğiniz seri portun adını belirtin
        //    int baudRate = 9600; // Baud rate ayarını yapın (örneğin 9600)

        //    using SerialPort serialPort = new SerialPort(portName, baudRate);

        //    serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

        //    try
        //    {
        //        serialPort.Open();
        //        Console.WriteLine("Serial port opened successfully. Listening for incoming messages...");

        //        // Programın çalışmasını devam ettirir
        //        Console.WriteLine("Press any key to exit...");
        //        Console.ReadKey();

        //        serialPort.Close();
        //        Console.WriteLine("Serial port closed.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("An error occurred: " + ex.Message);
        //    }
        //}

        //private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        //{
        //    SerialPort sp = (SerialPort)sender;
        //    string inData = sp.ReadExisting();
        //    Console.WriteLine("Message received: " + inData);
        //}
        #endregion

    }
}
