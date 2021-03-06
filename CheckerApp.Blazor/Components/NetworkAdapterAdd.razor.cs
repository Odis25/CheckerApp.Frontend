using CheckerApp.Blazor.Models.Hardware;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace CheckerApp.Blazor.Components
{
    public partial class NetworkAdapterAdd
    {
        private NetworkAdapterDto Device { get; set; } = new ();
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        private void Save() => MudDialog.Close(DialogResult.Ok(Device));       
    }
}
