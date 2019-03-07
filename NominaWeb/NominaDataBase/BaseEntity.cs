using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace NominaDataBase
{
    public abstract class BaseMetaDataEntity
    {
        [DisplayName("Ultima fecha actualización")]
        public Nullable<System.DateTime> last_update_date
        {
            get; set;
        }

        [DisplayName("Fecha creación")]
        public Nullable<System.DateTime> creation_Date
        {
            get; set;
        }

        [DisplayName("Ultimo usuario actualización")]
        public string last_user_update
        {
            get; set;
        }
    }
}