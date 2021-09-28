using CheckerApp.Blazor.Models.Commands;
using FluentValidation;

namespace CheckerApp.Blazor.Common.Validators
{
    public class CreateSoftwareCommandValidator : AbstractValidator<CreateSoftwareCommandVm>
    {
        public CreateSoftwareCommandValidator()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
        }
    }
}
