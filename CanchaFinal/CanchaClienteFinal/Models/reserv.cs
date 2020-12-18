using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanchaClienteFinal.Models
{
    public class reserv
    {
        public CanchaConexion.Models.Deportes depo { get; set; }
        public CanchaConexion.Models.Recintos reci { get; set; }
    }
}