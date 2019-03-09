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
    public class TipoDeduccionController : Controller
    {
        private NominaDBEntities db = new NominaDBEntities();

        // GET: TipoDeduccion
        public ActionResult Index()
        {
            return View(db.Tipos_Deducciones.ToList());
        }

        // GET: TipoDeduccion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos_Deducciones tipos_Deducciones = db.Tipos_Deducciones.Find(id);
            if (tipos_Deducciones == null)
            {
                return HttpNotFound();
            }
            return View(tipos_Deducciones);
        }

        // GET: TipoDeduccion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDeduccion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoDeduccion,Nombre,DependeSalario,Estado")] Tipos_Deducciones tipos_Deducciones)
        {
            if (ModelState.IsValid)
            {
                db.Tipos_Deducciones.Add(tipos_Deducciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipos_Deducciones);
        }

        // GET: TipoDeduccion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos_Deducciones tipos_Deducciones = db.Tipos_Deducciones.Find(id);
            if (tipos_Deducciones == null)
            {
                return HttpNotFound();
            }
            return View(tipos_Deducciones);
        }

        // POST: TipoDeduccion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoDeduccion,Nombre,DependeSalario,Estado")] Tipos_Deducciones tipos_Deducciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipos_Deducciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipos_Deducciones);
        }

        // GET: TipoDeduccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipos_Deducciones tipos_Deducciones = db.Tipos_Deducciones.Find(id);
            if (tipos_Deducciones == null)
            {
                return HttpNotFound();
            }
            return View(tipos_Deducciones);
        }

        // POST: TipoDeduccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipos_Deducciones tipos_Deducciones = db.Tipos_Deducciones.Find(id);
            db.Tipos_Deducciones.Remove(tipos_Deducciones);
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
