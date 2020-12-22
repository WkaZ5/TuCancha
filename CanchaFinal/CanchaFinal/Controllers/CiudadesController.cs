using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CanchaConexion.Models;
using CanchaFinal.Models;
using System.Net;
using System.Data.Entity;
using System.Data;
using System.Text;
using System.Security.Cryptography;

namespace CanchaFinal.Controllers
{
    public class CiudadesController : Controller
    {
        private TuCanchaEntities db = new TuCanchaEntities();
        // GET: Ciudades
        public ActionResult Index()
        {
            if (Session["Adminn"] != null)
            {
                var can = db.Cuidades.Include(u => u.Regiones);
                return View(can.ToList());

            }
            else
            {
                return Redirect("../Menu/Menu");
            }

        }

        public ActionResult Create()
        {
            if (Session["Adminn"] != null)
            {
                ViewBag.region = new SelectList(db.Regiones, "id_regiones", "nombre");
                return View();
            }
            else
            {
                return Redirect("../Menu/Menu");
            }

        }

        // POST: Autores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cuidades cuidades)
        {
            if (Session["Adminn"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Cuidades.Add(cuidades);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.recinto = new SelectList(db.Regiones, "id_regiones", "nombre", cuidades.region);
                return View(cuidades);
            }
            else
            {
                return Redirect("../Menu/Menu");
            }

        }

        public ActionResult Details(int? id)
        {
            if (Session["Adminn"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cuidades ciudades = db.Cuidades.Find(id);
                if (ciudades == null)
                {
                    return HttpNotFound();
                }
                return View(ciudades);
            }
            else
            {
                return Redirect("../Menu/Menu");
            }
        }

        public ActionResult Edit(int? id)
        {
            if (Session["Adminn"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cuidades cll = db.Cuidades.Find(id);

                if (cll == null)
                {
                    return HttpNotFound();
                }
                ViewBag.region = new SelectList(db.Regiones, "id_regiones", "nombre", cll.region);
                return View(cll);

            }
            else
            {
                return Redirect("../Menu/Menu");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cuidades ciu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ciu).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.region = new SelectList(db.Regiones, "id_regiones", "nombre", ciu.region);
            return View(ciu);
        }


        //public ActionResult Delete(string rut)
        //{
        //    if (rut == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Clientes cll = db.Clientes.Find(rut);
        //    if (cll == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cll);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string rut)
        //{
        //    Clientes clie = db.Clientes.Find(rut);
        //    db.Clientes.Remove(clie);
        //    db.SaveChanges();
        //    return RedirectToAction("Clientes");
        //}

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
