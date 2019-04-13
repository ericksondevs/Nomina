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
    public class PuestoController : BaseController
    {
        private NominaDBEntities db = new NominaDBEntities();

        // GET: Puesto
        public ActionResult Index()
        {
            var puestos = db.Puestos.Include(p => p.Departamentos);
            return View(puestos.ToList());
        }

        // GET: Puesto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puestos puestos = db.Puestos.Find(id);
            if (puestos == null)
            {
                return HttpNotFound();
            }
            return View(puestos);
        }

        // GET: Puesto/Create
        public ActionResult Create()
        {
            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDepartamento", "Nombre");
            return View();
        }

        // POST: Puesto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPuesto,Puesto,IdDepartamento,SalarioMinimo,SalarioMaximo")] Puestos puestos)
        {
            if (ModelState.IsValid)
            {
                db.Puestos.Add(puestos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDepartamento", "Nombre", puestos.IdDepartamento);
            return View(puestos);
        }

        // GET: Puesto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puestos puestos = db.Puestos.Find(id);
            if (puestos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDepartamento", "Nombre", puestos.IdDepartamento);
            return View(puestos);
        }

        // POST: Puesto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPuesto,Puesto,IdDepartamento,SalarioMinimo,SalarioMaximo")] Puestos puestos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(puestos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDepartamento", "Nombre", puestos.IdDepartamento);
            return View(puestos);
        }

        // GET: Puesto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puestos puestos = db.Puestos.Find(id);
            if (puestos == null)
            {
                return HttpNotFound();
            }
            return View(puestos);
        }

        // POST: Puesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Puestos puestos = db.Puestos.Find(id);
            db.Puestos.Remove(puestos);
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
