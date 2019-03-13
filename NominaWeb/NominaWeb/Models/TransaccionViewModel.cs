using NominaDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NominaWeb.Models
{
    public  class TransaccionViewModel
    {
        public Maestro_Transacciones Maestra { get; set; }
        public Detalle_Transacciones Detalle { get; set; }
    }
}