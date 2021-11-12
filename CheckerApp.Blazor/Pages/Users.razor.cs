using CheckerApp.Blazor.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CheckerApp.Blazor.Pages
{
    public partial class Users
    {
        [Inject] ISnackbar Snackbar { get; set; }
        [Inject] IHttpClientFactory HttpClientFactory { get; set; }
        private string searchString = "";

        IList<Account> Accounts { get; set; }
        HttpClient HttpClient { get; set; }

        protected override async Task OnInitializedAsync()
        {
            HttpClient = HttpClientFactory.CreateClient("AuthServer");
            Accounts = await HttpClient.GetFromJsonAsync<IList<Account>>("account/checkerapp");
        }

        private async Task SaveChanges()
        {
            await HttpClient.PutAsJsonAsync("account/checkerapp", Accounts);
            Snackbar.Add("Изменения сохранены", Severity.Success);
        }

        private bool FilterFunc(Account account)
        {
            if (string.IsNullOrWhiteSpace(searchString)) return true;

            if (account.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase)) return true;
            if (account.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase)) return true;
            if (account.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)) return true;
            if (account.Role.Contains(searchString, StringComparison.OrdinalIgnoreCase)) return true;

            return false;
        }
    }
}
