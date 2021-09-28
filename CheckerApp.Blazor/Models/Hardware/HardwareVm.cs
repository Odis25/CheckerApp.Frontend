using CheckerApp.Blazor.Common.Enums;
using System;

namespace CheckerApp.Blazor.Models.Hardware
{
    public class HardwareVm
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string SerialNumber { get; set; }
        public HardwareType HardwareType { get; set; }

        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
