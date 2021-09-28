using System.ComponentModel.DataAnnotations;

namespace CheckerApp.Blazor.Models.Commands
{
    public class UpdateContractCommandVm
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Это поле обязательно для заполнения")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        public string ContractNumber { get; set; }
        public string DomesticNumber { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        public string ProjectNumber { get; set; }
    }
}
