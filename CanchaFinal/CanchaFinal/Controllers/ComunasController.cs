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
    public class ComunasController : Controller
    {
        private TuCanchaEntities db = new TuCanchaEntities();
        // GET: Comunas
        public ActionResult Index()
        {
            if (Session["Adminn"] != null)
            {
                var can = db.Comunas.Include(u => u.Cuidades);
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
                ViewBag.cuidad = new SelectList(db.Cuidades, "id_cuidad", "nombre");
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
        public ActionResult Create(Comunas comunas)
        {
            if (Session["Adminn"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Comunas.Add(comunas);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.cuidad = new SelectList(db.Cuidades, "id_cuidad", "nombre", comunas.cuidad);
                return View(comunas);
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
                Comunas comunas = db.Comunas.Find(id);
                if (comunas == null)
                {
                    return HttpNotFound();
                }
                return View(comunas);
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
                Comunas cll = db.Comunas.Find(id);

                if (cll == null)
                {
                    return HttpNotFound();
                }
                ViewBag.cuidad = new SelectList(db.Cuidades, "id_cuidad", "nombre", cll.cuidad);
                return View(cll);

            }
            else
            {
                return Redirect("../Menu/Menu");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comunas ciu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ciu).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cuidad = new SelectList(db.Cuidades, "id_regiones", "nombre", ciu.cuidad);
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