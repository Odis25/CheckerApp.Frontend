using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Threading.Tasks;

namespace CheckerApp.Blazor.Shared
{
    public partial class LoginDisplay
    {
        [Inject] NavigationManager Navigation { get; set; }
        [Inject] SignOutSessionStateManager SignOutManager { get; set; }

        private async Task BeginSignOut(MouseEventArgs args)
        {
            await SignOutManager.SetSignOutState();
            Navigation.NavigateTo("authentication/logout");
        }

        private void BeginSignIn(MouseEventArgs args)
        {
            Navigation.NavigateTo("authentication/login");
        }
    }
}
