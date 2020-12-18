using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CanchaClienteFinal.Models
{
    public class Clienteccf
        
    {
     
        
        [Required(ErrorMessage = "Este campo es requerido.", AllowEmptyStrings = true)]
        public string Rut { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.", AllowEmptyStrings = true)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.", AllowEmptyStrings = true)]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.", AllowEmptyStrings = true)]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.", AllowEmptyStrings = true)]
        public DateTime Edad { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.", AllowEmptyStrings = true)]
        public string Contraseña { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.", AllowEmptyStrings = true)]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.", AllowEmptyStrings = true)]     
        public int Comuna { get; set; }
    }
}