using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NominaDataBase.MetaDataEntities
{
    public class Maestro_TransaccionesMetaData
    {
        [DisplayName("Empleado")]
        public int IdEmpleado { get; set; }

        [Display(Name = "Tipo de Ingreso")]
        public int IdTipoIngreso { get; set; }

        [Display(Name = "Tipo de deducción")]
        public int IdTipoDeduccion { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Display(Name = "Tipo de Transacción")]
        public string TipoTransaccion { get; set; }
    }
}