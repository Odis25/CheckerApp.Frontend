using CheckerApp.Blazor.Common.JsonConverters;
using CheckerApp.Blazor.Models.Checks;
using CheckerApp.Blazor.Models.Commands;
using CheckerApp.Blazor.Models.Software;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace CheckerApp.Blazor.Pages
{
    public partial class CheckHardwareForm
    {
        [Inject] ISnackbar Snackbar { get; set; }
        [Inject] protected HttpClient HttpClient { get; set; }
        [Inject] protected NavigationManager Navigation { get; set; }

        [Parameter] public string Id { get; set; }

        protected CheckListVm CheckList { get; set; } = new CheckListVm();

        protected SoftwareCheckDto[] ScadaList { get; set; }

        JsonSerializerOptions JsonOptions { get; set; }

        protected async override Task OnInitializedAsync()
        {
            JsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters =
                {
                    new HardwareConverter(),
                    new SoftwareConverter()
                }
            };

            CheckList = await HttpClient.GetFromJsonAsync<CheckListVm>($"api/check/{int.Parse(Id)}", JsonOptions);

            ScadaList = CheckList.SoftwareChecks.Where(e => e.Software is ScadaDto).ToArray();
        }

        protected async Task Submit()
        {
            var command = new UpsertCheckResultCommandVm { CheckResult = CheckList };

            var result = await HttpClient.PostAsJsonAsync($"api/check", command, JsonOptions);

            if (result.IsSuccessStatusCode)
            {
                Navigation.NavigateTo($"/contract/{Id}/detail");
                Snackbar.Add("Заводские испытания проведены", Severity.Success);
            }
        }
    }
}
