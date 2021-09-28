using CheckerApp.Blazor.Models.Commands;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CheckerApp.Blazor.Components
{
    public partial class ContractAdd
    {
        [Inject] HttpClient HttpClient { get; set; }
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        private CreateContractCommandVm _contract = new();

        protected async Task Submit()
        {
            var response = await HttpClient.PostAsJsonAsync("api/contract", _contract);
            var id = await response.Content.ReadAsStringAsync();

            MudDialog.Close(DialogResult.Ok(id));
        }
    }
}
