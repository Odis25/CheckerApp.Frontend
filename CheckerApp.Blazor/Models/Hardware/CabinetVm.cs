using CheckerApp.Blazor.Common.Enums;
using System;

namespace CheckerApp.Blazor.Models.Hardware
{
    public class CabinetVm : HardwareVm
    {
        public CabinetVm()
        {
            HardwareType = HardwareType.Cabinet;
        }
        public DateTime? Constructed { get; set; }
        public string ConstructedBy { get; set; }
    }
}
