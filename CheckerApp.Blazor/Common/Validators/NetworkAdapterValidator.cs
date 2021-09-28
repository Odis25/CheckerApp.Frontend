using CheckerApp.Blazor.Models.Hardware;
using FluentValidation;

namespace CheckerApp.Blazor.Common.Validators
{
    public class NetworkAdapterValidator : AbstractValidator<NetworkAdapterDto>
    {
        public NetworkAdapterValidator()
        {
            RuleFor(e => e.IP).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            RuleFor(e => e.MacAddress).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
        }
    }
}
