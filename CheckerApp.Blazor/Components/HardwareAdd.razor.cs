using CheckerApp.Blazor.Common.Enums;
using CheckerApp.Blazor.Models.Commands;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CheckerApp.Blazor.Components
{
    public partial class HardwareAdd
    {
        private readonly HardwareType[] _hardwareTypes = Enum.GetValues(typeof(HardwareType)).Cast<HardwareType>().ToArray();

        [Inject] HttpClient HttpClient { get; set; }
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [CascadingParameter] IDialogService DialogService { get; set; }
        [Parameter] public string ContractId { get; set; }

        public CreateHardwareCommandVm Command { get; set; }

        protected override void OnInitialized()
        {
            Command = new CreateHardwareCommandVm
            {
                ContractId = int.Parse(ContractId)
            };
        }

        private async Task Submit()
        {
            var response = await HttpClient.PostAsJsonAsync("api/hardware", Command);
            var id = await response.Content.ReadAsStringAsync();

            MudDialog.Close(DialogResult.Ok(id));
        }

        private void UpdateWidth()
        {
            if (Command.HardwareType == HardwareType.Network)
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
    }
}
