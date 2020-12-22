using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CanchaFinal.Models
{
    public class Adminn
    {
        [Display(Name = "Rut")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [RegularExpression(@"^([0-9]{8})-([0-9][k]{1})$", ErrorMessage = "Rut incorrecto")]
        [DataType(DataType.Text)]
        public string Rut { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(15, ErrorMessage = "Longitud entre 4 y 15 caracteres.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }
    }
}