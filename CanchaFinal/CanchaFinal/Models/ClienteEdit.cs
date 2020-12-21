using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CanchaFinal.Models
{
    public class ClienteEdit
    {
        
        public string rut { get; set; }

        [Display(Name = "nombre")]
        [Required(ErrorMessage = "Este campo es requerido.", AllowEmptyStrings = true)]
        public string nombre { get; set; }

        [Display(Name = "apellido")]
        [Required(ErrorMessage = "Este campo es requerido.", AllowEmptyStrings = true)]
        public string apellido { get; set; }

        [Display(Name = "direccion")]
        [Required(ErrorMessage = "Este campo es requerido.", AllowEmptyStrings = true)]
        public string direccion { get; set; }

        [Display(Name = "edad")]
        [Required(ErrorMessage = "Este campo es requerido.", AllowEmptyStrings = true)]
        public DateTime edad { get; set; }

        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Este campo es requerido.", AllowEmptyStrings = true)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100")]
        [DataType(DataType.EmailAddress)]
        public string correo { get; set; }

        public bool habilitado { get; set; }

        [Display(Name = "comuna")]
        public int comuna { get; set; }
    }
}