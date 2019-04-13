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
    public class TiposIngresosController : BaseController
    {
        private NominaDBEntities db = new NominaDBEntities();

        // GET: Tipos_Ingresos
        public ActionResult Index()
        {
            return View(db.Tipos_Ingresos.ToList());
        }

        // GET: Tipos_Ingresos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos_Ingresos tipos_Ingresos = db.Tipos_Ingresos.Find(id);
            if (tipos_Ingresos == null)
            {
                return HttpNotFound();
            }
            return View(tipos_Ingresos);
        }

        // GET: Tipos_Ingresos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipos_Ingresos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoIngreso,Nombre,DependeSalario,Estado")] Tipos_Ingresos tipos_Ingresos)
        {
            if (ModelState.IsValid)
            {
                db.Tipos_Ingresos.Add(tipos_Ingresos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipos_Ingresos);
        }

        // GET: Tipos_Ingresos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos_Ingresos tipos_Ingresos = db.Tipos_Ingresos.Find(id);
            if (tipos_Ingresos == null)
            {
                return HttpNotFound();
            }
            return View(tipos_Ingresos);
        }

        // POST: Tipos_Ingresos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoIngreso,Nombre,DependeSalario,Estado")] Tipos_Ingresos tipos_Ingresos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipos_Ingresos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipos_Ingresos);
        }

        // GET: Tipos_Ingresos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos_Ingresos tipos_Ingresos = db.Tipos_Ingresos.Find(id);
            if (tipos_Ingresos == null)
            {
                return HttpNotFound();
            }
            return View(tipos_Ingresos);
        }

        // POST: Tipos_Ingresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipos_Ingresos tipos_Ingresos = db.Tipos_Ingresos.Find(id);
            db.Tipos_Ingresos.Remove(tipos_Ingresos);
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
