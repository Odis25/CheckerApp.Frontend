using CheckerApp.Blazor.Common.Enums;
using CheckerApp.Blazor.Models.Commands;
using FluentValidation;

namespace CheckerApp.Blazor.Common.Validators
{
    public class CreateHardwareCommandValidator : AbstractValidator<CreateHardwareCommandVm>
    {
        public CreateHardwareCommandValidator()
        {
            When(m => m.HardwareType == HardwareType.Cabinet, () =>
            {
                RuleFor(m => m.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.Position).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.ConstructedBy).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            });
            When(m => m.HardwareType == HardwareType.Pressure ||
            m.HardwareType == HardwareType.DiffPressure ||
            m.HardwareType == HardwareType.GasAnalyzer ||
            m.HardwareType == HardwareType.FireSensor ||
            m.HardwareType == HardwareType.APC ||
            m.HardwareType == HardwareType.InformPanel ||
            m.HardwareType == HardwareType.Temperature, () =>
            {
                RuleFor(m => m.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.Position).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.DeviceModel).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.DeviceType).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            });
            When(m => m.HardwareType == HardwareType.Flowmeter, () =>
            {
                RuleFor(m => m.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.Position).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.DeviceModel).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.DeviceType).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            });
            When(m => m.HardwareType == HardwareType.FlowComputer, () =>
            {
                RuleFor(m => m.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.Position).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.DeviceModel).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            });
            When(m => m.HardwareType == HardwareType.PLC, () =>
            {
                RuleFor(m => m.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.Position).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.DeviceModel).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            });
            When(m => m.HardwareType == HardwareType.Network, () =>
            {
                RuleFor(m => m.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.Position).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.DeviceType).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.DeviceModel).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            });
            When(m => m.HardwareType == HardwareType.Valve, () =>
            {
                RuleFor(m => m.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.Position).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.DeviceType).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.DeviceModel).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            });
            When(m => m.HardwareType == HardwareType.ARM, () =>
            {
                RuleFor(m => m.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.ArmName).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.Monitor).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.MonitorSN).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            });
        }
    }
}
