namespace GpioDataApp.GpioDataApp.Communication.Interfaces
{
    public interface ISerialPortManager
    {
        void OpenPort();
        void ClosePort();
        Task SendMessageAsync(string message);
    }
}
