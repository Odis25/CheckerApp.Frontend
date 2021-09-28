using CheckerApp.Blazor.Models.Hardware;
using CheckerApp.Blazor.Models.Software;
using System;
using System.Collections.Generic;

namespace CheckerApp.Blazor.Models.Contract
{
    public class ContractDetailVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractNumber { get; set; }
        public string DomesticNumber { get; set; }
        public string ProjectNumber { get; set; }
        public bool HasProtocol { get; set; }

        public IEnumerable<HardwareVm> HardwareList { get; set; }
        public IEnumerable<SoftwareDto> SoftwareList { get; set; }

        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
