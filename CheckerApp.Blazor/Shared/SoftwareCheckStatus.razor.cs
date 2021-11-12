using CheckerApp.Blazor.Common.Enums;
using CheckerApp.Blazor.Models.Checks;
using Microsoft.AspNetCore.Components;

namespace CheckerApp.Blazor.Shared
{
    public partial class SoftwareCheckStatus
    {
        [Parameter] public SoftwareCheckDto Value { get; set; }

        [Parameter] public EventCallback<SoftwareCheckDto> ValueChanged { get; set; }

        string Type { get; set; }
        string Name { get; set; }
        string Version { get; set; }

        protected override void OnInitialized()
        {
            Type = Value.Software.SoftwareType.GetDisplayName();
            Name = Value.Software.Name;
            Version = Value.Software.Version;
        }
    }
}
