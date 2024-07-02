namespace GpioDataApp.GpioDataApp.Business.Interfaces
{
    public interface IKeyService
    {
        void MonitorKeyStatus(Action<string> keyStatusChanged);
    }
}
