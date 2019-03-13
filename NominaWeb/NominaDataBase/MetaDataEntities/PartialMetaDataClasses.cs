using NominaDataBase.MetaDataEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NominaDataBase
{
    //[System.ComponentModel.DataAnnotations.MetadataType(typeof(BaseMetaDataEntity))] 
    //public partial class Departamentos : BaseMetaDataEntity { }

    [MetadataType(typeof(Maestro_TransaccionesMetaData))]
    public partial class Maestro_Transacciones : BaseMetaDataEntity { }

    [MetadataType(typeof(DetalleTransaccionesMetaData))]
    public partial class Detalle_Transacciones : BaseMetaDataEntity { }
}