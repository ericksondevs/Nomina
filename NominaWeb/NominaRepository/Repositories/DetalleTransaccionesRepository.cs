using System.Data.Entity;

namespace NominaRepository.Repositories
{
    public class DetalleTransaccionesRepository : BaseRepository<NominaDataBase.Detalle_Transacciones>
    {
        public DetalleTransaccionesRepository(DbContext context) : base(context)
        {

        }
    }
}