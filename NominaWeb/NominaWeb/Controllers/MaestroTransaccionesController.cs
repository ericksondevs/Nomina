using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NominaDataBase;

namespace NominaWeb.Controllers
{
    public class MaestroTransaccionesController : Controller
    {
        private NominaDBEntities db = new NominaDBEntities();

        // GET: MaestroTransacciones
        public ActionResult Index()
        {
            var maestro_Transacciones = db.Maestro_Transacciones.Include(m => m.Empleados).Include(m => m.Tipos_Deducciones).Include(m => m.Tipos_Ingresos);
            return View(maestro_Transacciones.ToList());
        }

        // GET: MaestroTransacciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maestro_Transacciones maestro_Transacciones = db.Maestro_Transacciones.Find(id);
            if (maestro_Transacciones == null)
            {
                return HttpNotFound();
            }
            return View(maestro_Transacciones);
        }

        // GET: MaestroTransacciones/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Cedula");
            ViewBag.IdTipoDeduccion = new SelectList(db.Tipos_Deducciones, "IdTipoDeduccion", "Nombre");
            ViewBag.IdTipoIngreso = new SelectList(db.Tipos_Ingresos, "IdTipoIngreso", "Nombre");
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
                db.Maestro_Transacciones.Add(maestro_Transacciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Cedula", maestro_Transacciones.IdEmpleado);
            ViewBag.IdTipoDeduccion = new SelectList(db.Tipos_Deducciones, "IdTipoDeduccion", "Nombre", maestro_Transacciones.IdTipoDeduccion);
            ViewBag.IdTipoIngreso = new SelectList(db.Tipos_Ingresos, "IdTipoIngreso", "Nombre", maestro_Transacciones.IdTipoIngreso);
            return View(maestro_Transacciones);
        }

        // GET: MaestroTransacciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maestro_Transacciones maestro_Transacciones = db.Maestro_Transacciones.Find(id);
            if (maestro_Transacciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Cedula", maestro_Transacciones.IdEmpleado);
            ViewBag.IdTipoDeduccion = new SelectList(db.Tipos_Deducciones, "IdTipoDeduccion", "Nombre", maestro_Transacciones.IdTipoDeduccion);
            ViewBag.IdTipoIngreso = new SelectList(db.Tipos_Ingresos, "IdTipoIngreso", "Nombre", maestro_Transacciones.IdTipoIngreso);
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
                db.Entry(maestro_Transacciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Cedula", maestro_Transacciones.IdEmpleado);
            ViewBag.IdTipoDeduccion = new SelectList(db.Tipos_Deducciones, "IdTipoDeduccion", "Nombre", maestro_Transacciones.IdTipoDeduccion);
            ViewBag.IdTipoIngreso = new SelectList(db.Tipos_Ingresos, "IdTipoIngreso", "Nombre", maestro_Transacciones.IdTipoIngreso);
            return View(maestro_Transacciones);
        }

        // GET: MaestroTransacciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maestro_Transacciones maestro_Transacciones = db.Maestro_Transacciones.Find(id);
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
            Maestro_Transacciones maestro_Transacciones = db.Maestro_Transacciones.Find(id);
            db.Maestro_Transacciones.Remove(maestro_Transacciones);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
