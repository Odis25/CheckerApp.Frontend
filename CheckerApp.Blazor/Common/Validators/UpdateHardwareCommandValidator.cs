using CheckerApp.Blazor.Common.Enums;
using CheckerApp.Blazor.Models.Commands;
using CheckerApp.Blazor.Models.Hardware;
using FluentValidation;

namespace CheckerApp.Blazor.Common.Validators
{
    public class UpdateHardwareCommandValidator : AbstractValidator<UpdateHardwareCommandVm>
    {
        public UpdateHardwareCommandValidator()
        {
            When(m => m.Hardware.HardwareType == HardwareType.Cabinet, () =>
            {
                RuleFor(m => m.Hardware.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.Hardware.Position).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => ((CabinetVm)m.Hardware).ConstructedBy).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            });
            When(m => m.Hardware.HardwareType == HardwareType.Pressure ||
            m.Hardware.HardwareType == HardwareType.DiffPressure ||
            m.Hardware.HardwareType == HardwareType.GasAnalyzer ||
            m.Hardware.HardwareType == HardwareType.Temperature, () =>
            {
                RuleFor(m => m.Hardware.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.Hardware.Position).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => ((MeasurementVm)m.Hardware).DeviceModel).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => ((MeasurementVm)m.Hardware).DeviceType).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            });
            When(m => m.Hardware.HardwareType == HardwareType.Flowmeter, () =>
            {
                RuleFor(m => m.Hardware.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.Hardware.Position).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => ((MeasurementVm)m.Hardware).DeviceModel).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => ((MeasurementVm)m.Hardware).DeviceType).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            });
            When(m => m.Hardware.HardwareType == HardwareType.FireModule, () =>
            {
                RuleFor(m => m.Hardware.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.Hardware.Position).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => ((FireModuleVm)m.Hardware).DeviceType).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            });
            When(m => m.Hardware.HardwareType == HardwareType.FlowComputer, () =>
            {
                RuleFor(m => m.Hardware.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.Hardware.Position).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => ((FlowComputerVm)m.Hardware).DeviceModel).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            });
            When(m => m.Hardware.HardwareType == HardwareType.PLC, () =>
            {
                RuleFor(m => m.Hardware.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.Hardware.Position).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => ((PlcVm)m.Hardware).DeviceModel).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            });
            When(m => m.Hardware.HardwareType == HardwareType.Network, () =>
            {
                RuleFor(m => m.Hardware.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.Hardware.Position).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => ((NetworkHardwareVm)m.Hardware).DeviceType).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => ((NetworkHardwareVm)m.Hardware).DeviceModel).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            });
            When(m => m.Hardware.HardwareType == HardwareType.Valve, () =>
            {
                RuleFor(m => m.Hardware.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => m.Hardware.Position).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => ((ValveVm)m.Hardware).DeviceType).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => ((ValveVm)m.Hardware).DeviceModel).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            });
            When(m => m.Hardware.HardwareType == HardwareType.ARM, () =>
            {
                RuleFor(m => m.Hardware.SerialNumber).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => ((ArmVm)m.Hardware).Name).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => ((ArmVm)m.Hardware).Monitor).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
                RuleFor(m => ((ArmVm)m.Hardware).MonitorSN).NotEmpty().WithMessage("Это поле обязательно для заполнения.");
            });
        }
    }
}
