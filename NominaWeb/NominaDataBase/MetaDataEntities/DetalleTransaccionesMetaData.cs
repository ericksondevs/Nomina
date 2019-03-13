using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NominaDataBase.MetaDataEntities
{
    public partial class DetalleTransaccionesMetaData
    {
        [Display(Name = "Id Transacción")]
        public int IdTransaccion { get; set; }
     
        [Display(Name = "Fecha")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public System.DateTime Fecha { get; set; }
        [Display(Name = "Monto")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal Monto { get; set; }
        [Display(Name = "Estado")]
        public string Estado { get; set; }
        [Display(Name = "Maestro Transaccion")]
        public int IdMaestroTransaccion { get; set; }
    }
}