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
    public class TipoTransaccionController : Controller
    {
        private NominaDBEntities db = new NominaDBEntities();

        // GET: TipoTransaccion
        public ActionResult Index()
        {
            return View(db.TipoTransaccion.ToList());
        }

        // GET: TipoTransaccion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTransaccion tipoTransaccion = db.TipoTransaccion.Find(id);
            if (tipoTransaccion == null)
            {
                return HttpNotFound();
            }
            return View(tipoTransaccion);
        }

        // GET: TipoTransaccion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoTransaccion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoTransaccion,Descripcion")] TipoTransaccion tipoTransaccion)
        {
            if (ModelState.IsValid)
            {
                db.TipoTransaccion.Add(tipoTransaccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoTransaccion);
        }

        // GET: TipoTransaccion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTransaccion tipoTransaccion = db.TipoTransaccion.Find(id);
            if (tipoTransaccion == null)
            {
                return HttpNotFound();
            }
            return View(tipoTransaccion);
        }

        // POST: TipoTransaccion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoTransaccion,Descripcion")] TipoTransaccion tipoTransaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoTransaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoTransaccion);
        }

        // GET: TipoTransaccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTransaccion tipoTransaccion = db.TipoTransaccion.Find(id);
            if (tipoTransaccion == null)
            {
                return HttpNotFound();
            }
            return View(tipoTransaccion);
        }

        // POST: TipoTransaccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoTransaccion tipoTransaccion = db.TipoTransaccion.Find(id);
            db.TipoTransaccion.Remove(tipoTransaccion);
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
