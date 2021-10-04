using CheckerApp.Blazor.Common.JsonConverters;
using CheckerApp.Blazor.Models.Commands;
using CheckerApp.Blazor.Models.Software;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace CheckerApp.Blazor.Components
{
    public partial class SoftwareUpdate
    {
        [Inject] HttpClient HttpClient { get; set; }
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public SoftwareDto Software { get; set; }
        public UpdateSoftwareCommandVm Command { get; set; }

        protected override void OnInitialized()
        {
            Command = new UpdateSoftwareCommandVm
            {
                Id = Software.Id,
                Name = Software.Name,
                Version = Software.Version
            };
        }
        protected async Task Submit()
        {
            var options = new JsonSerializerOptions { Converters = { new SoftwareConverter() } };

            await HttpClient.PutAsJsonAsync("api/software", Command, options);

            MudDialog.Close(DialogResult.Ok(Software.Id));
        }
    }
}
