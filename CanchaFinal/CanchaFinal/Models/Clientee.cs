using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanchaFinal.Models
{
    public class Clientee
    {
        public string rut { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public int edad { get; set; }
        public string contraseña { get; set; }
        public string correo { get; set; }
        public bool habilitado { get; set; }
        public string comuna { get; set; }
        
    }
}