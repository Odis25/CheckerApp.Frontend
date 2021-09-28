using CheckerApp.Blazor.Common.Enums;

namespace CheckerApp.Blazor.Models.Hardware
{
    public class PressureVm : MeasurementVm
    {
        public PressureVm()
        {
            HardwareType = HardwareType.Pressure;
        }
    }
}
