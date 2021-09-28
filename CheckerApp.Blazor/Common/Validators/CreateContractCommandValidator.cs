using CheckerApp.Blazor.Models.Commands;
using FluentValidation;

namespace CheckerApp.Blazor.Common.Validators
{
    public class CreateContractCommandValidator : AbstractValidator<CreateContractCommandVm>
    {
        public CreateContractCommandValidator()
        {
            RuleFor(c => c.ContractNumber).NotEmpty().WithMessage("Не указан номер договора.");
            RuleFor(c => c.ProjectNumber).NotEmpty().WithMessage("Не указан внутренний номер проекта.");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Не указано название договора.");
        }
    }
}
