namespace CheckerApp.Blazor.Models.Hardware
{
    public class ControllerVm : HardwareVm
    {
        public string DeviceModel { get; set; }
        public string AssemblyVersion { get; set; }
        public string IP { get; set; }
    }
}
