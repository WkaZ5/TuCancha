using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CanchaFinal.Models
{
    public class Canchass
    {
        
        public int Id_cancha { get; set; }
        [Display(Name = "nombre")]
        [Required(ErrorMessage = "Este campo es requerido.", AllowEmptyStrings = true)]
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public int Recinto { get; set; }
        [Display(Name = "hora incial")]
        [Required(ErrorMessage = "Este campo es requerido.", AllowEmptyStrings = true)]
        public System.TimeSpan Hora_inicio { get; set; }
        [Display(Name = "Hora final")]
        [Required(ErrorMessage = "Este campo es requerido.", AllowEmptyStrings = true)]
        public System.TimeSpan Hora_final { get; set; }
        public int Deporte { get; set; }
    }
}