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
    
    public partial class Detalle_Transacciones
    {
        public int IdTransaccion { get; set; }
        public string TipoTransaccion { get; set; }
        public System.DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Estado { get; set; }
    }
}
