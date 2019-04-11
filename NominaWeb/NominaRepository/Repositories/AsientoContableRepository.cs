using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NominaRepository.Repositories
{
    public class AsientoContableRepository : BaseRepository<AsientoContableRepository>
    {
        public AsientoContableRepository(DbContext context) : base(context)
        {

        }
    }
}