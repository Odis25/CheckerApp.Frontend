using CheckerApp.Blazor.Models.Hardware;
using System.Collections.Generic;

namespace CheckerApp.Blazor.Models.Checks
{
    public class HardwareCheckDto
    {
        public HardwareCheckDto()
        {
            CheckParameters = new List<CheckParameterDto>();
        }

        public HardwareVm Hardware { get; set; }
        public IList<CheckParameterDto> CheckParameters { get; set; }
    }
}
