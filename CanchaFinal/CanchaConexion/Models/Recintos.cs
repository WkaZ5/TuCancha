//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CanchaConexion.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recintos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recintos()
        {
            this.Canchas = new HashSet<Canchas>();
        }
    
        public int id_recinto { get; set; }
        public string nombre { get; set; }
        public Nullable<bool> estado { get; set; }
        public int administrador { get; set; }
        public int comuna { get; set; }
        public Nullable<bool> eliminado { get; set; }
        public Nullable<System.DateTime> fecha_elim { get; set; }
    
        public virtual Administradores Administradores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Canchas> Canchas { get; set; }
        public virtual Comunas Comunas { get; set; }
    }
}