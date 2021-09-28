using CheckerApp.Blazor.Common.Enums;

namespace CheckerApp.Blazor.Models.Hardware
{
    public class DiffPressureVm : MeasurementVm
    {
        public DiffPressureVm()
        {
            HardwareType = HardwareType.DiffPressure;
        }
    }
}
