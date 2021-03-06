using System.Collections.Generic;
using CheckerApp.Blazor.Common.Enums;

namespace CheckerApp.Blazor.Models.Hardware
{
    public class NetworkHardwareVm : HardwareVm
    {
        public NetworkHardwareVm()
        {
            NetworkDevices = new List<NetworkDeviceDto>();
            HardwareType = HardwareType.Network;
            Mask = "255.255.255.0";
        }
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public string Mask { get; set; }
        public IList<NetworkDeviceDto> NetworkDevices { get; set; }
    }
    public class NetworkDeviceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public string MacAddress { get; set; }
    }
}
