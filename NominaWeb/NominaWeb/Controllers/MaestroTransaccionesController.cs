using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NominaDataBase;
using NominaRepository;

namespace NominaWeb.Controllers
{
    public class MaestroTransaccionesController : Controller
    {
        private NominaDBEntities db = new NominaDBEntities();
        UnitOfWork u = new UnitOfWork();
        // GET: MaestroTransacciones
        public ActionResult Index(string searchName)
        {
            var maestro_Transacciones = u.TransaccionesRepository.GetAll().AsQueryable().Include(m => m.Empleados).Include(m => m.Tipos_Deducciones).Include(m => m.Tipos_Ingresos).Include(x => x.Detalle_Transacciones);

            // Filter down if necessary
            if (!String.IsNullOrEmpty(searchName))
            {
                maestro_Transacciones = maestro_Transacciones.Where(p => p.IdTransaccion.ToString() == searchName);
            }

            return View(maestro_Transacciones.ToList());
        }

        public void LoadViewBags(Maestro_Transacciones maestro_Transacciones = null)
        {
            if (maestro_Transacciones == null)
            {
                ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Nombre");
                ViewBag.IdTipoDeduccion = new SelectList(db.Tipos_Deducciones, "IdTipoDeduccion", "Nombre");
                ViewBag.IdTipoIngreso = new SelectList(db.Tipos_Ingresos, "IdTipoIngreso", "Nombre");
                ViewBag.TipoTransaccion = new SelectList(db.TipoTransaccion, "IdTipoTransaccion", "Descripcion");
            }
            else
            {
                ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Cedula", maestro_Transacciones.IdEmpleado);
                ViewBag.IdTipoDeduccion = new SelectList(db.Tipos_Deducciones, "IdTipoDeduccion", "Nombre", maestro_Transacciones.IdTipoDeduccion);
                ViewBag.IdTipoIngreso = new SelectList(db.Tipos_Ingresos, "IdTipoIngreso", "Nombre", maestro_Transacciones.IdTipoIngreso);
                ViewBag.TipoTransaccion = new SelectList(db.TipoTransaccion, "IdTipoTransaccion", "Descripcion", maestro_Transacciones.TipoTransaccion);

            }
        }
        // GET: MaestroTransacciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Maestro_Transacciones maestro_Transacciones = u.TransaccionesRepository.Find(id);

            if (maestro_Transacciones == null)
            {
                return HttpNotFound();
            }
            return View(maestro_Transacciones);
        }

        // GET: MaestroTransacciones/Create
        public ActionResult Create()
        {
            LoadViewBags();
            return View();
        }

        // POST: MaestroTransacciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTransaccion,IdEmpleado,IdTipoIngreso,IdTipoDeduccion,Estado")] Maestro_Transacciones maestro_Transacciones)
        {
            if (ModelState.IsValid)
            {
                u.TransaccionesRepository.Add(maestro_Transacciones);
                u.SaveChanges();
                return RedirectToAction("Index");
            }

            LoadViewBags();
            return View(maestro_Transacciones);
        }

        // GET: MaestroTransacciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maestro_Transacciones maestro_Transacciones = u.TransaccionesRepository.Find(id);
            if (maestro_Transacciones == null)
            {
                return HttpNotFound();
            }

            LoadViewBags();

            return View(maestro_Transacciones);
        }

        // POST: MaestroTransacciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTransaccion,IdEmpleado,IdTipoIngreso,IdTipoDeduccion,Estado")] Maestro_Transacciones maestro_Transacciones)
        {
            if (ModelState.IsValid)
            {
                u.TransaccionesRepository.Update(maestro_Transacciones);
                u.SaveChanges();
                return RedirectToAction("Index");
            }

            LoadViewBags();

            return View(maestro_Transacciones);
        }

        // GET: MaestroTransacciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maestro_Transacciones maestro_Transacciones = u.TransaccionesRepository.Find(id);
            if (maestro_Transacciones == null)
            {
                return HttpNotFound();
            }
            return View(maestro_Transacciones);
        }

        // POST: MaestroTransacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maestro_Transacciones maestro_Transacciones = u.TransaccionesRepository.Find(id);
            u.TransaccionesRepository.Remove(maestro_Transacciones);
            u.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                u.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}