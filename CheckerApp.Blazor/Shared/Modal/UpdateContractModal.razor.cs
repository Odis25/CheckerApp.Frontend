using CheckerApp.Blazor.Models.Commands;
using CheckerApp.Blazor.Models.Contract;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CheckerApp.Blazor.Shared.Modal
{
    public partial class UpdateContractModal
    {
        [Inject] HttpClient HttpClient { get; set; }
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public ContractDetailVm Contract { get; set; }

        UpdateContractCommandVm Command { get; set; }

        protected override void OnParametersSet()
        {
            Command = new UpdateContractCommandVm
            {
                Id = Contract.Id,
                Name = Contract.Name,
                ContractNumber = Contract.ContractNumber,
                ProjectNumber = Contract.ProjectNumber,
                DomesticNumber = Contract.DomesticNumber
            };
        }

        protected async Task Submit()
        {
            await HttpClient.PutAsJsonAsync("api/contract", Command);

            MudDialog.Close(DialogResult.Ok(Contract.Id));
        }
    }
}
