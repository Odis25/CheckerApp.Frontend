using CheckerApp.Blazor.Common.Enums;

namespace CheckerApp.Blazor.Models.Hardware
{
    public class PlcVm : ControllerVm
    {
        public PlcVm()
        {
            HardwareType = HardwareType.PLC;
        }
    }
}
