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
    public class NominaController : Controller
    {
        private NominaDBEntities db = new NominaDBEntities();

        // GET: Nomina
        public ActionResult Index()
        {
            var hello = new List<Nominas>();

            foreach (var x in db.Nominas.ToList())
            {
                hello.Add(new Nominas()
                {
                    IdNomina = x.IdNomina,
                    Nombre = x.Nombre,
                    TipoNomina = x.Banco,
                    Banco = x.Banco,
                    fechaDesdeConverted = x.fechaDesde.ToString("dd/MM/yy"),
                    fechahastaConverted = x.fechaHasta.ToString("dd/MM/yy"),
                    FechaEfectividadConverted = x.FechaEfectividad.ToString("dd/MM/yy"),
                    Monto = x.Monto,
                    Total_AFP = x.Total_AFP,
                    Total_ARS = x.Total_ARS,
                    Total_ISR = x.Total_ISR,
                    Total_ingresos = x.Total_ingresos,
                    Total_Otros_descuentos = x.Total_Otros_descuentos,
                    Observaciones = x.Observaciones,
                    Estado = x.Estado
                });
            }

            return View(hello);
        }

        // GET: Nomina/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nominas nominas = db.Nominas.Find(id);
            if (nominas == null)
            {
                return HttpNotFound();
            }
            return View(nominas);
        }

        // GET: Nomina/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nomina/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdNomina,Nombre,TipoNomina,Banco,fechaDesde,fechaHasta,FechaEfectividad,Monto,Total_AFP,Total_ARS,Total_ISR,Total_ingresos,Total_Otros_descuentos,Observaciones,Estado")] Nominas nominas)
        {
                if (ModelState.IsValid)
                {
                if (nominas.fechaDesdeConverted.ToString().Equals(nominas.fechahastaConverted.ToString()))
                {
                    ViewBag.FechaErrorMessage = "FEECHA INCORRECTAS";
                }
                else
                    {
                        db.Nominas.Add(nominas);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                }
            
            return View(nominas);
        }

        // GET: Nomina/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nominas nominas = db.Nominas.Find(id);
            if (nominas == null)
            {
                return HttpNotFound();
            }
            return View(nominas);
        }

        // POST: Nomina/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdNomina,Nombre,TipoNomina,Banco,fechaDesde,fechaHasta,FechaEfectividad,Monto,Total_AFP,Total_ARS,Total_ISR,Total_ingresos,Total_Otros_descuentos,Observaciones,Estado")] Nominas nominas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nominas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nominas);
        }

        // GET: Nomina/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nominas nominas = db.Nominas.Find(id);
            if (nominas == null)
            {
                return HttpNotFound();
            }
            return View(nominas);
        }

        // POST: Nomina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nominas nominas = db.Nominas.Find(id);
            db.Nominas.Remove(nominas);
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
