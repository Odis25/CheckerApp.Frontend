using CheckerApp.Blazor.Models.Software;
using System.Collections.Generic;

namespace CheckerApp.Blazor.Models.Checks
{
    public class SoftwareCheckDto
    {
        public SoftwareCheckDto()
        {
            CheckParameters = new List<CheckParameterDto>();
        }

        public SoftwareDto Software { get; set; }
        public IList<CheckParameterDto> CheckParameters { get; set; }
    }
}
