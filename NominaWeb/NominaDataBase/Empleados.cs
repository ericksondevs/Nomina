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
    
    public partial class Empleados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleados()
        {
            this.AsientosContables = new HashSet<AsientosContables>();
            this.Maestro_Transacciones = new HashSet<Maestro_Transacciones>();
        }
    
        public int IdEmpleado { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdDepartamento { get; set; }
        public int IdPuesto { get; set; }
        public decimal Salario { get; set; }
        public Nullable<decimal> Salario_H_Extra { get; set; }
        public Nullable<decimal> Salario_H_Ordinarias { get; set; }
        public System.DateTime FechaIngreso { get; set; }
        public int IdNomina { get; set; }
        public string Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AsientosContables> AsientosContables { get; set; }
        public virtual Departamentos Departamentos { get; set; }
        public virtual Nominas Nominas { get; set; }
        public virtual Puestos Puestos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Maestro_Transacciones> Maestro_Transacciones { get; set; }
        public virtual Nominas Nominas1 { get; set; }
    }
}
