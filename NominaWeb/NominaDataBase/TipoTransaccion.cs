//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NominaDataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class TipoTransaccion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoTransaccion()
        {
            this.Maestro_Transacciones = new HashSet<Maestro_Transacciones>();
        }
    
        public int IdTipoTransaccion { get; set; }
        public string Descripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Maestro_Transacciones> Maestro_Transacciones { get; set; }
    }
}
