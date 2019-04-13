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
    public class AsientoContableController : BaseController
    {
        private NominaDBEntities db = new NominaDBEntities();

        // GET: AsientoContable
        public ActionResult Index()
        {
            var asientosContables = db.AsientosContables.Include(a => a.Empleados);
            return View(asientosContables.ToList());
        }

        // GET: AsientoContable/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsientosContables asientosContables = db.AsientosContables.Find(id);
            if (asientosContables == null)
            {
                return HttpNotFound();
            }
            return View(asientosContables);
        }

        // GET: AsientoContable/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Cedula");
            return View();
        }

        // POST: AsientoContable/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAsiento,Descripcion,IdEmpleado,Cuenta,TipoMovimiento,FechaAsiento,MontoAsiento,Estado")] AsientosContables asientosContables)
        {
            if (ModelState.IsValid)
            {
                db.AsientosContables.Add(asientosContables);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Cedula", asientosContables.IdEmpleado);
            return View(asientosContables);
        }

        // GET: AsientoContable/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsientosContables asientosContables = db.AsientosContables.Find(id);
            if (asientosContables == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Cedula", asientosContables.IdEmpleado);
            return View(asientosContables);
        }

        // POST: AsientoContable/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAsiento,Descripcion,IdEmpleado,Cuenta,TipoMovimiento,FechaAsiento,MontoAsiento,Estado")] AsientosContables asientosContables)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asientosContables).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Cedula", asientosContables.IdEmpleado);
            return View(asientosContables);
        }

        // GET: AsientoContable/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsientosContables asientosContables = db.AsientosContables.Find(id);
            if (asientosContables == null)
            {
                return HttpNotFound();
            }
            return View(asientosContables);
        }

        // POST: AsientoContable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsientosContables asientosContables = db.AsientosContables.Find(id);
            db.AsientosContables.Remove(asientosContables);
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
