using NominaDataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NominaRepository.Repositories
{
    public class MaestroTransaccionesRepository : BaseRepository<Maestro_Transacciones>
    {
        public MaestroTransaccionesRepository(DbContext context) : base(context)
        {
       
        }

        public void CreateTransaction(Maestro_Transacciones maestra, Detalle_Transacciones detalle)
        {
            detalle.IdMaestroTransaccion = maestra.IdTransaccion;

            this.dbSet.Add(maestra);
            this.context.Set<Detalle_Transacciones>().Add(detalle);

        }
    }
}