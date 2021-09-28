using CheckerApp.Blazor.Common.Enums;
using System.Collections.Generic;

namespace CheckerApp.Blazor.Models.Hardware 
{ 
    public class ArmVm : HardwareVm
    {
        public ArmVm()
        {
            HardwareType = HardwareType.ARM;
        }
        public string Name { get; set; }
        public string Monitor { get; set; }
        public string MonitorSN { get; set; }
        public string Keyboard { get; set; }
        public string KeyboardSN { get; set; }
        public string Mouse { get; set; }
        public string MouseSN { get; set; }
        public bool HasRAID { get; set; }

        public string OS { get; set; }
        public string ProductKeyOS { get; set; }

        public List<NetworkAdapterDto> NetworkAdapters { get; set; }
    }

    public class NetworkAdapterDto
    {
        public string IP { get; set; }
        public string MacAddress { get; set; }
    }
}
