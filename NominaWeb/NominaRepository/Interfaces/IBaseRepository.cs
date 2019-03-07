using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.NominaRepository
{
    public interface IBaseRepository<T> where T : class
    {
        void Commit();
        void Dispose();
    }
}
