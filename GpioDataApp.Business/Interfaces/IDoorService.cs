using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpioDataApp.GpioDataApp.Business.Interfaces
{
    public interface IDoorService
    {
        void MonitorDoorStatus(Action<string> doorStatusChanged);
    }
}
