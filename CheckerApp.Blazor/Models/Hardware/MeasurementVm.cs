using CheckerApp.Blazor.Common.Enums;

namespace CheckerApp.Blazor.Models.Hardware
{
    public class MeasurementVm : HardwareVm
    {
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public string EU { get; set; }
        public SignalType SignalType { get; set; }
    }
}
