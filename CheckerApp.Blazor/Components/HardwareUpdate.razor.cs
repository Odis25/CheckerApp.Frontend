using CheckerApp.Blazor.Common.Enums;
using CheckerApp.Blazor.Common.JsonConverters;
using CheckerApp.Blazor.Models.Commands;
using CheckerApp.Blazor.Models.Hardware;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace CheckerApp.Blazor.Components
{
    public partial class HardwareUpdate
    {
        [Inject] HttpClient HttpClient { get; set; }
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public HardwareVm Hardware { get; set; }

        UpdateHardwareCommandVm Command { get; set; }

        protected override void OnParametersSet()
        {
            Command = new UpdateHardwareCommandVm
            {
                Hardware = Hardware
            };
            UpdateWidth();
        }
        private void UpdateWidth()
        {
            if (Hardware.HardwareType == HardwareType.Network)
            {
                MudDialog.Options.MaxWidth = MaxWidth.Medium;
                MudDialog.SetOptions(MudDialog.Options);
            }
            else
            {
                MudDialog.Options.MaxWidth = MaxWidth.Small;
                MudDialog.SetOptions(MudDialog.Options);
            }
        }
        protected async Task Submit()
        {
            var options = new JsonSerializerOptions { Converters = { new HardwareConverter() } };

            await HttpClient.PutAsJsonAsync("api/hardware", Command, options);

            MudDialog.Close(DialogResult.Ok(Hardware.Id));
        }
    }
}
