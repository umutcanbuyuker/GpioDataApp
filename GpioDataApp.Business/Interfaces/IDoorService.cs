namespace GpioDataApp.GpioDataApp.Business.Interfaces
{
    public interface IDoorService
    {
        string GetDoorStatus();
        void MonitorDoorStatus(Action<string> doorStatusChanged);
    }
}
