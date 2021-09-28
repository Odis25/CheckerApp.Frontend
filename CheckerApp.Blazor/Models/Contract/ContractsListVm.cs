using System.Collections.Generic;

namespace CheckerApp.Blazor.Models.Contract
{
    public class ContractsListVm
    {
        public IList<ContractDto> Contracts { get; set; }
    }
}
