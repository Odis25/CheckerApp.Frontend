using System;

namespace CheckerApp.Blazor.Models.Contract
{
    public class ContractDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractNumber { get; set; }
        public string DomesticNumber { get; set; }
        public string ProjectNumber { get; set; }
        public DateTime LastChanges { get; set; }
        public bool HasProtocol { get; set; }
    }
}
