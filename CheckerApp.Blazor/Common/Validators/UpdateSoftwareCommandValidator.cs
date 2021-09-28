using CheckerApp.Blazor.Models.Commands;
using FluentValidation;

namespace CheckerApp.Blazor.Common.Validators
{
    public class UpdateSoftwareCommandValidator : AbstractValidator<UpdateSoftwareCommandVm>
    {
        public UpdateSoftwareCommandValidator()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
        }
    }
}
