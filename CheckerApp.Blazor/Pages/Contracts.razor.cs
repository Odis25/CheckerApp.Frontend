using CheckerApp.Blazor.Models.Contract;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CheckerApp.Blazor.Pages
{
    public partial class Contracts
    {
        private string searchString = "";

        [Inject] IHttpClientFactory HttpClientFactory { get; set; }
        [Inject] NavigationManager Navigation { get; set; }

        ContractsListVm ContractsList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var client = HttpClientFactory.CreateClient("Unauthorized");
            ContractsList = await client.GetFromJsonAsync<ContractsListVm>("api/contract");
        }

        public void OpenContractDetails(TableRowClickEventArgs<ContractDto> args)
        {
            if (args.MouseEventArgs.Detail == 2)
            {
                var id = args.Item.Id;
                Navigation.NavigateTo($"Contract/{id}/detail");
            }
        }

        private bool FilterFunc(ContractDto device)
        {
            var filtredString = searchString;

            if (string.IsNullOrWhiteSpace(filtredString)) return true;

            if (device.Name.Contains(filtredString, StringComparison.OrdinalIgnoreCase)) return true;
            if (device.ProjectNumber.Contains(filtredString, StringComparison.OrdinalIgnoreCase)) return true;
            if (device.ContractNumber.Contains(filtredString, StringComparison.OrdinalIgnoreCase)) return true;
            if (device.DomesticNumber.Contains(filtredString, StringComparison.OrdinalIgnoreCase)) return true;
            if (device.LastChanges.ToShortDateString().Contains(filtredString, StringComparison.OrdinalIgnoreCase)) return true;

            return false;
        }
    }
}
