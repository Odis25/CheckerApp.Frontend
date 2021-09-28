using CheckerApp.Blazor.Common.Enums;

namespace CheckerApp.Blazor.Models.Hardware
{
    public class FlowComputerVm : ControllerVm
    {
        public FlowComputerVm()
        {
            HardwareType = HardwareType.FlowComputer;
        }
        public string CRC32 { get; set; }
        public long? LastConfigDate { get; set; }
    }
}
