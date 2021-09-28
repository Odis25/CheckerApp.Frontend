using CheckerApp.Blazor.Models.Hardware;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CheckerApp.Blazor.Components
{
    public partial class NetworkDeviceUpdate
    {
        [Parameter] public NetworkDeviceDto NetworkDevice { get; set; }
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }
        private NetworkDeviceDto Value { get; set; } = new();

        protected override void OnInitialized()
        {
            Value.Id = NetworkDevice.Id;
            Value.IP = NetworkDevice.IP;
            Value.MacAddress = NetworkDevice.MacAddress;
            Value.Name = NetworkDevice.Name;
        }
        public void Save() => MudDialog.Close(DialogResult.Ok(Value));
    }
}
