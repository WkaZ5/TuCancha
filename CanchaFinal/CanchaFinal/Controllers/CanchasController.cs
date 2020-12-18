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
    public class CanchasController : Controller
    {
        private TuCanchaEntities db = new TuCanchaEntities();
        // GET: Canchas
        public ActionResult Canchas()
        {
            if (Session["Adminn"] != null)
            {
                var can = db.Canchas.Include(u => u.Recintos).Include(u =>u.Deportes);
                return View(can.ToList());
                
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
                ViewBag.recinto = new SelectList(db.Recintos, "id_recinto", "nombre");
                ViewBag.deporte = new SelectList(db.Deportes, "id_deporte", "nombre");
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
        public ActionResult Create(Canchas canchas)
        {
            if (Session["Adminn"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Canchas.Add(canchas);
                    db.SaveChanges();
                    return RedirectToAction("Canchas");
                }

                ViewBag.recinto = new SelectList(db.Recintos, "id_recinto", "nombre", canchas.recinto);
                ViewBag.deporte = new SelectList(db.Deportes, "id_deporte", "nombre", canchas.deporte);
                return View(canchas);
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
                Canchas autores = db.Canchas.Find(id);
                if (autores == null)
                {
                    return HttpNotFound();
                }
                return View(autores);
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
                Canchas cll = db.Canchas.Find(id);
                
                if (cll == null)
                {
                    return HttpNotFound();
                }
                ViewBag.recinto = new SelectList(db.Recintos, "id_recinto", "nombre", cll.recinto);
                ViewBag.deporte = new SelectList(db.Deportes, "id_deporte", "nombre", cll.deporte);
                return View(cll);

            }
            else
            {
                return View("../Menu/Menu");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Canchas canchas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(canchas).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Canchas");
            }
            
            ViewBag.recinto = new SelectList(db.Recintos, "id_recinto", "nombre", canchas.recinto);
            ViewBag.deporte = new SelectList(db.Deportes, "id_deporte", "nombre", canchas.deporte);
            return View(canchas);
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