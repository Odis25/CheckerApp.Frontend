using CheckerApp.Blazor.Common.JsonConverters;
using CheckerApp.Blazor.Models.Hardware;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace CheckerApp.Blazor.Pages
{
    public partial class HardwareDetail
    {
        [Inject] IHttpClientFactory HttpClientFactory { get; set; }
        [Parameter] public string Id { get; set; }

        HardwareVm Hardware { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var client = HttpClientFactory.CreateClient("Unauthorized");

            var options = new JsonSerializerOptions { Converters = { new HardwareConverter() } };

            Hardware = await client.GetFromJsonAsync<HardwareVm>($"api/hardware/{int.Parse(Id)}", options);
        }
    }
}
