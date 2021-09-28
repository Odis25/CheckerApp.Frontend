using System.ComponentModel.DataAnnotations;

namespace CheckerApp.Blazor.Common.Enums
{
    public enum SignalType
    {
        [Display(Name = "Токовый (4-20 мА)")]
        Current,
        [Display(Name = "Дискретный")]
        Discrete,
        [Display(Name = "Ethernet")]
        Ethernet,
        [Display(Name = "Импульсный")]
        Frequency,
        [Display(Name = "HART")]
        HART,
        [Display(Name = "RS-485")]
        RS485,
        [Display(Name = "Напряжение (1-5 В)")]
        Voltage
    }
}
