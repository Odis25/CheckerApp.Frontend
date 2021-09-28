using CheckerApp.Blazor.Common.Enums;

namespace CheckerApp.Blazor.Models.Hardware
{
    public class GasAnalyzerVm : MeasurementVm
    {
        public GasAnalyzerVm()
        {
            HardwareType = HardwareType.GasAnalyzer;
        }
    }
}
