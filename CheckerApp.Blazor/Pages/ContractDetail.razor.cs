using CheckerApp.Blazor.Common.JsonConverters;
using CheckerApp.Blazor.Components;
using CheckerApp.Blazor.Models.Commands;
using CheckerApp.Blazor.Models.Contract;
using CheckerApp.Blazor.Models.Hardware;
using CheckerApp.Blazor.Models.Software;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using MudBlazor;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace CheckerApp.Blazor.Pages
{
    public partial class ContractDetail
    {
        private bool _readonly = true;
        private string _created;
        private string _edited;
        private HttpClient _httpClient;
        private MudForm _form;

        [Inject] IHttpClientFactory HttpClientFactory { get; set; }
        [Inject] IDialogService DialogService { get; set; }
        [Inject] NavigationManager Navigation { get; set; }
        [Inject] IConfiguration Configuration { get; set; }

        [Parameter] public string Id { get; set; }
        [CascadingParameter] private Task<AuthenticationState> AuthenticationStateTask { get; set; }

        protected ContractDetailVm Contract { get; set; }
        protected UpdateContractCommandVm Command { get; set; } = new();
        protected string ProtocolCss => Contract.HasProtocol ? "protocol" : "no-protocol";
        protected string DownloadLink { get => $"{Configuration["apis:data_host"]}/api/check/download/{Id}"; }

        protected async override Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateTask;
            if (authState.User.Identity.IsAuthenticated)
            {
                _httpClient = HttpClientFactory.CreateClient("API");
            }
            else
            {
                _httpClient = HttpClientFactory.CreateClient("Unauthorized");
            }
            await UpdateData();
        }

        private void CreateDocument()
        {
            Navigation.NavigateTo($"/contract/{Id}/check");
        }

        private async Task AddHardware()
        {
            var options = new DialogOptions
            {
                CloseButton = true,
                FullWidth = true
            };
            var parameters = new DialogParameters { { "ContractId", Id } };
            var dialog = DialogService.Show<HardwareAdd>("Новое оборудование", parameters, options);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await UpdateData();
            }
        }
        public async Task UpdateHardware(int id)
        {
            var jsonOptions = new JsonSerializerOptions { Converters = { new HardwareConverter() } };
            var hardware = await _httpClient.GetFromJsonAsync<HardwareVm>($"api/hardware/{id}", jsonOptions);
            var parameters = new DialogParameters { ["Hardware"] = hardware };
            var options = new DialogOptions
            {
                CloseButton = true,
                FullWidth = true
            };

            var dialog = DialogService.Show<HardwareUpdate>("Редактирование", parameters, options);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await UpdateData();
            }
        }
        private async Task DeleteHardware(int id)
        {
            await _httpClient.DeleteAsync($"api/hardware/{id}");
            await UpdateData();
        }

        private async Task AddSoftware()
        {
            var parameters = new DialogParameters { { "ContractId", Id } };
            var modalForm = DialogService.Show<SoftwareAdd>("Новое ПО", parameters);
            var result = await modalForm.Result;

            if (!result.Cancelled)
            {
                await UpdateData();
            }
        }
        private async Task UpdateSoftware(int id)
        {
            var software = await _httpClient.GetFromJsonAsync<SoftwareDto>($"api/software/{id}");
            var parameters = new DialogParameters { { "Software", software } };
            var dialog = DialogService.Show<SoftwareUpdate>("Редактирование", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await UpdateData();
            }
        }
        private async Task DeleteSoftware(int id)
        {
            await _httpClient.DeleteAsync($"api/software/{id}");
            await UpdateData();
        }

        private async Task UpdateContract()
        {
            await _form.Validate();
            var isValid = _form.IsValid;
            if (isValid)
            {
                await _httpClient.PutAsJsonAsync($"api/contract", Command);
                await UpdateData();
                _readonly = true;
            }
        }
        private async Task DeleteContract()
        {
            var result = await DialogService.ShowMessageBox(
                title: $"Удаление договора {Contract.ContractNumber}",
                message: "Вы уверены что хотите удалить этот договор?",
                yesText: "Да",
                noText: "Нет");

            if (result.HasValue)
            {
                await _httpClient.DeleteAsync($"api/contract/{Contract.Id}");
                Navigation.NavigateTo("/contract");
            }
        }

        public void OpenHardwareDetails(TableRowClickEventArgs<HardwareVm> args)
        {
            if (args.MouseEventArgs.Detail == 2)
            {
                var id = args.Item.Id;
                Navigation.NavigateTo($"/hardware/{id}/detail");
            }
        }

        private void SwitchEditMode()
        {
            Command = new UpdateContractCommandVm
            {
                Id = Contract.Id,
                Name = Contract.Name,
                ContractNumber = Contract.ContractNumber,
                ProjectNumber = Contract.ProjectNumber,
                DomesticNumber = Contract.DomesticNumber
            };

            _readonly = !_readonly;
        }
        private async Task UpdateData()
        {
            Contract = await _httpClient.GetFromJsonAsync<ContractDetailVm>($"api/contract/{Id}");

            _created = $"{Contract.Created:dd/MM/yyyy - HH:mm:ss} ({Contract.CreatedBy})";
            _edited = Contract.LastModified != null ? $"{Contract.LastModified:dd/MM/yyyy - HH:mm:ss} ({Contract.LastModifiedBy})" : "----";
        }
    }
}
