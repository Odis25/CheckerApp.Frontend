using CheckerApp.Blazor.Components;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Threading.Tasks;

namespace CheckerApp.Blazor.Shared
{
    public partial class NavMenu
    {
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] IDialogService DialogService { get; set; }

        private async Task AddContract()
        {
            var options = new DialogOptions
            {
                CloseButton = true,
                FullWidth = true
            };
            var dialog = DialogService.Show<ContractAdd>("Новый договор", options);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                var contractId = result.Data.ToString();

                NavigationManager.NavigateTo($"/contract/{contractId}/detail");
            }
        }
    }
}
