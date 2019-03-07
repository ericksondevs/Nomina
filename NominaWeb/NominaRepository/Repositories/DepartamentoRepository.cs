using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace NominaRepository.Repositories
{
    public class DepartamentoRepository : BaseRepository<NominaDataBase.Departamentos>
    {
        public DepartamentoRepository(DbContext context) : base(context)
        {

        }
    }
}