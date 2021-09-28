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
    public partial class SoftwareAdd
    {
        private readonly SoftwareType[] _softwareTypes = Enum.GetValues(typeof(SoftwareType)).Cast<SoftwareType>().ToArray();

        [Inject] HttpClient HttpClient { get; set; }
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public string ContractId { get; set; }

        CreateSoftwareCommandVm Command { get; set; }

        protected override void OnInitialized()
        {
            Command = new CreateSoftwareCommandVm
            {
                ContractId = int.Parse(ContractId)
            };
        }

        private async Task Submit()
        {
            var response = await HttpClient.PostAsJsonAsync("api/software", Command);
            var id = await response.Content.ReadAsStringAsync();

            MudDialog.Close(DialogResult.Ok(id));
        }
    }
}
