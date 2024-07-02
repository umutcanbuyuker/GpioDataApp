namespace GpioDataApp.GpioDataApp.Business.Interfaces
{
    public interface IDoorService
    {
        void MonitorDoorStatus(Action<string> doorStatusChanged);
    }
}
