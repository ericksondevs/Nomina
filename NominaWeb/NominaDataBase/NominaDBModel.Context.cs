﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NominaDBEntities : DbContext
    {
        public NominaDBEntities()
            : base("name=NominaDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AsientosContables> AsientosContables { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Detalle_Transacciones> Detalle_Transacciones { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Maestro_Transacciones> Maestro_Transacciones { get; set; }
        public virtual DbSet<Nominas> Nominas { get; set; }
        public virtual DbSet<Puestos> Puestos { get; set; }
        public virtual DbSet<Tipos_Deducciones> Tipos_Deducciones { get; set; }
        public virtual DbSet<Tipos_Ingresos> Tipos_Ingresos { get; set; }
        public virtual DbSet<TipoTransaccion> TipoTransaccion { get; set; }
    }
}
