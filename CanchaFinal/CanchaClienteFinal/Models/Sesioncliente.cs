using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CanchaClienteFinal.Models
{
    public class Sesioncliente
    {
        [Required(ErrorMessage = "Este campo es requerido.", AllowEmptyStrings = true)]
        public string Rut { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.", AllowEmptyStrings = true)]
        public string Contraseña { get; set; }
    }
}