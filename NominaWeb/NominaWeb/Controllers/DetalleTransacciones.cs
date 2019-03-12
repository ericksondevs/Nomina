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
    public class DetalleTransacciones : Controller
    {
        private NominaDBEntities db = new NominaDBEntities();

        // GET: DetalleTransacciones
        public ActionResult Index()
        {
            return View(db.Detalle_Transacciones.ToList());
        }

        // GET: DetalleTransacciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Transacciones detalle_Transacciones = db.Detalle_Transacciones.Find(id);
            if (detalle_Transacciones == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Transacciones);
        }

        // GET: DetalleTransacciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetalleTransacciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTransaccion,TipoTransaccion,Fecha,Monto,Estado")] Detalle_Transacciones detalle_Transacciones)
        {
            if (ModelState.IsValid)
            {
                db.Detalle_Transacciones.Add(detalle_Transacciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(detalle_Transacciones);
        }

        // GET: DetalleTransacciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Transacciones detalle_Transacciones = db.Detalle_Transacciones.Find(id);
            if (detalle_Transacciones == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Transacciones);
        }

        // POST: DetalleTransacciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTransaccion,TipoTransaccion,Fecha,Monto,Estado")] Detalle_Transacciones detalle_Transacciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_Transacciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detalle_Transacciones);
        }

        // GET: DetalleTransacciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Transacciones detalle_Transacciones = db.Detalle_Transacciones.Find(id);
            if (detalle_Transacciones == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Transacciones);
        }

        // POST: DetalleTransacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle_Transacciones detalle_Transacciones = db.Detalle_Transacciones.Find(id);
            db.Detalle_Transacciones.Remove(detalle_Transacciones);
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
