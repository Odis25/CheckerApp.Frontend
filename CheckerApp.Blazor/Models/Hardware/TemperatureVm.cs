using CheckerApp.Blazor.Common.Enums;

namespace CheckerApp.Blazor.Models.Hardware
{
    public class TemperatureVm : MeasurementVm
    {
        public TemperatureVm()
        {
            HardwareType = HardwareType.Temperature;
        }
    }
}
