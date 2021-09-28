using CheckerApp.Blazor.Common.Enums;

namespace CheckerApp.Blazor.Models.Hardware
{
    public class FlowmeterVm : MeasurementVm
    {
        public FlowmeterVm()
        {
            HardwareType = HardwareType.Flowmeter;
        }
        public double? Kfactor { get; set; }
        public ModbusSettingsVm ModbusSettings { get; set; }
    }
}
