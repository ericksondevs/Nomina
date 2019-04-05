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
    public class EmpleadoController : Controller
    {
        private NominaDBEntities db = new NominaDBEntities();

        // GET: Empleado
        public ActionResult Index()
        {
            var empleados = db.Empleados.Include(e => e.Departamentos).Include(e => e.Puestos);
            return View(empleados.ToList());
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDepartamento", "Nombre");
            ViewBag.IdNomina = new SelectList(db.Nominas, "IdNomina", "Nombre");
            ViewBag.IdPuesto = new SelectList(db.Puestos, "IdPuesto", "Puesto");
            //ViewBag.IdNomina = new SelectList(db.Nominas, "IdNomina", "Nombre");
            return View();
        }

        public static bool validateId(string pCedula)
        {
            int vnTotal = 0;
            string vcCedula = pCedula.Replace("-", "");
            int pLongCed = vcCedula.Trim().Length;
            int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

            if (pLongCed < 11 || pLongCed > 11)
                return false;

            for (int vDig = 1; vDig <= pLongCed; vDig++)
            {
                int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                if (vCalculo < 10)
                    vnTotal += vCalculo;
                else
                    vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));
            }

            if (vnTotal % 10 == 0)
                return true;
            else
                return false;

        }

        // POST: Empleado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmpleado,Cedula,Nombre,Apellido,IdDepartamento,IdPuesto,Salario,Salario_H_Extra,Salario_H_Ordinarias,FechaIngreso,IdNomina,Estado")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                if (!validateId(empleados.Cedula))
                {
                    ViewBag.CedulaErrorMessage = "La cedula es incorrecta";
                    //return View();
                }
                else
                {
                    db.Empleados.Add(empleados);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDepartamento", "Nombre", empleados.IdDepartamento);
            //ViewBag.IdNomina = new SelectList(db.Nominas, "IdNomina", "Nombre", empleados.IdNomina);
            ViewBag.IdPuesto = new SelectList(db.Puestos, "IdPuesto", "Puesto", empleados.IdPuesto);
            //ViewBag.IdNomina = new SelectList(db.Nominas, "IdNomina", "Nombre", empleados.IdNomina);
            return View(empleados);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDepartamento", "Nombre", empleados.IdDepartamento);
            //ViewBag.IdNomina = new SelectList(db.Nominas, "IdNomina", "Nombre", empleados.IdNomina);
            ViewBag.IdPuesto = new SelectList(db.Puestos, "IdPuesto", "Puesto", empleados.IdPuesto);
            //ViewBag.IdNomina = new SelectList(db.Nominas, "IdNomina", "Nombre", empleados.IdNomina);
            return View(empleados);
        }

        // POST: Empleado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmpleado,Cedula,Nombre,Apellido,IdDepartamento,IdPuesto,Salario,Salario_H_Extra,Salario_H_Ordinarias,FechaIngreso,IdNomina,Estado")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDepartamento = new SelectList(db.Departamentos, "IdDepartamento", "Nombre", empleados.IdDepartamento);
            //ViewBag.IdNomina = new SelectList(db.Nominas, "IdNomina", "Nombre", empleados.IdNomina);
            ViewBag.IdPuesto = new SelectList(db.Puestos, "IdPuesto", "Puesto", empleados.IdPuesto);
            //ViewBag.IdNomina = new SelectList(db.Nominas, "IdNomina", "Nombre", empleados.IdNomina);
            return View(empleados);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleados empleados = db.Empleados.Find(id);
            db.Empleados.Remove(empleados);
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
