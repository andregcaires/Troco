using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Troco.Domain.Models
{
    public class Change
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Valor total da compra")]
        public double TotalValue { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Valor pago")]
        public double PaidValue { get; set; }

        public List<ChangeToReturn> ChangeToReturn { get; set; }
    }
}