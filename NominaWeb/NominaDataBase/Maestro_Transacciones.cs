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
    
    public partial class Maestro_Transacciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Maestro_Transacciones()
        {
            this.Detalle_Transacciones = new HashSet<Detalle_Transacciones>();
        }
    
        public int IdTransaccion { get; set; }
        public int IdEmpleado { get; set; }
        public Nullable<int> IdTipoIngreso { get; set; }
        public Nullable<int> IdTipoDeduccion { get; set; }
        public string Estado { get; set; }
    
        public virtual Empleados Empleados { get; set; }
        public virtual Tipos_Deducciones Tipos_Deducciones { get; set; }
        public virtual Tipos_Ingresos Tipos_Ingresos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_Transacciones> Detalle_Transacciones { get; set; }
    }
}
