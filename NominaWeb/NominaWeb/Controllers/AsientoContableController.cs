using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using NominaDataBase;

namespace NominaWeb.Controllers
{
    public class AsientoContableController : BaseController
    {
        //private NominaDBEntities db = new NominaDBEntities();

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

        class Header
        {
            public string auxiliar { get; set; }
            public string moneda { get; set; }
            public string descripcion { get; set; }
            public List<Detalle> detalle { get; set; }
        }

        class Detalle
        {
            public string numero_cuenta { get; set; }
            public string tipo_transaccion { get; set; }
            public string monto { get; set; }
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

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://prjaccounting20190327125427.azurewebsites.net");

                    var asiento = new Header();
                    var detalle = new Detalle();
                    var listaDetalle = new List<Detalle>();

                    asiento.auxiliar = "1";
                    asiento.descripcion = "Nomina";
                    asiento.moneda = "DOP";

                    detalle.monto = asientosContables.MontoAsiento.ToString();
                    detalle.numero_cuenta = asientosContables.Cuenta;
                    detalle.tipo_transaccion = "CR";

                    listaDetalle.Add(detalle);

                    var detalle2 = new Detalle();
                    detalle2.monto = asientosContables.MontoAsiento.ToString();
                    detalle2.numero_cuenta = asientosContables.Cuenta;
                    detalle2.tipo_transaccion = "DB";

                    listaDetalle.Add(detalle2);

                    asiento.detalle = listaDetalle;

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<Header>("/api/accounting/post", asiento);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

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
