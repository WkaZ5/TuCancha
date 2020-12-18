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
    public class RegionesController : Controller
    {
        private TuCanchaEntities db = new TuCanchaEntities();
        // GET: Regiones
        public ActionResult Index()
        {
            if (Session["Adminn"] != null)
            {
                return View(db.Regiones.ToList());
            }
            else
            {
                return View("../Menu/Menu");
            }
        }

        public ActionResult Create()
        {
            if (Session["Adminn"] != null)
            {
                return View();
            }
            else
            {
                return View("../Menu/Menu");
            }

        }

        // POST: Autores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Regiones regiones)
        {
            if (Session["Adminn"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Regiones.Add(regiones);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(regiones);
            }
            else
            {
                return View("../Menu/Menu");
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
                Regiones dep = db.Regiones.Find(id);
                if (dep == null)
                {
                    return HttpNotFound();
                }
                return View(dep);
            }
            else
            {
                return View("../Menu/Menu");
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
                Regiones cll = db.Regiones.Find(id);

                if (cll == null)
                {
                    return HttpNotFound();
                }
                return View(cll);

            }
            else
            {
                return View("../Menu/Menu");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Regiones dep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dep).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dep);
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