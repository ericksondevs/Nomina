using System;
using System.Collections.Generic;
using System.Text;
using NominaDataBase;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using NominaRepository.Repositories;
namespace NominaRepository
{
    public class UnitOfWork
    {
        string onlineUser = HttpContext.Current.User.Identity.Name;

        internal NominaDBEntities dbContext { get; } = null;

        public UnitOfWork()
        {
            dbContext = new NominaDBEntities();
        }

        private DepartamentoRepository departamentoRepository;

        public DepartamentoRepository DepartamentoRepository
        {
            get
            {
                if (this.departamentoRepository == null)
                {
                    this.departamentoRepository = new DepartamentoRepository(dbContext);
                }
                return departamentoRepository;
            }
        }

        private MaestroTransaccionesRepository transaccionesRepository;

        public MaestroTransaccionesRepository TransaccionesRepository
        {
            get
            {
                if (this.transaccionesRepository == null)
                {
                    this.transaccionesRepository = new MaestroTransaccionesRepository(dbContext);
                }
                return transaccionesRepository;
            }
        }

        private DetalleTransaccionesRepository detalletransaccionesRepository;

        public DetalleTransaccionesRepository DetalleTransaccionesRepository
        {
            get
            {
                if (this.detalletransaccionesRepository == null)
                {
                    this.detalletransaccionesRepository = new DetalleTransaccionesRepository(dbContext);
                }
                return detalletransaccionesRepository;
            }
        }

        private AsientoContableRepository asientoContableRepository;

        public AsientoContableRepository AsientoContableRepository
        {
            get
            {
                if (this.asientoContableRepository == null)
                {
                    this.asientoContableRepository = new AsientoContableRepository(dbContext);
                }
                return asientoContableRepository;
            }
        }

        public void SaveChanges()
        {
            AddLogInfo();

            try
            {
                dbContext.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void AddLogInfo()
        {
            var entities = dbContext.ChangeTracker.Entries().Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    if ((entity.Entity != null) && (entity.Entity.GetType().GetProperty("creation_Date") != null))
                    {
                        ((dynamic)entity.Entity).creation_Date = DateTime.Now;
                    }

                    if ((entity.Entity != null) && (entity.Entity.GetType().GetProperty("last_user_update") != null))
                    {
                        ((dynamic)entity.Entity).last_user_update = this.onlineUser;
                    }
                }

                if (entity.State == EntityState.Modified)
                {
                    if ((entity.Entity != null) && (entity.Entity.GetType().GetProperty("last_update_date") != null))
                    {
                        ((dynamic)entity.Entity).last_update_date = DateTime.Now;
                    }

                    if ((entity.Entity != null) && (entity.Entity.GetType().GetProperty("last_user_update") != null))
                    {
                        ((dynamic)entity.Entity).last_user_update = this.onlineUser;
                    }
                }
            }
        }
    }
}