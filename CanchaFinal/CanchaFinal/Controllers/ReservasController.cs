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
    public class ReservasController : Controller
    {
        private TuCanchaEntities db = new TuCanchaEntities();
        // GET: Reservas
        public ActionResult Reservas()
        {
            if (Session["Adminn"] != null)
            {
                var can = db.Reservas.Include(u => u.Clientes).Include(u => u.Canchas);
                return View(can.ToList());

            }
            else
            {
                return Redirect("../Menu/Menu");
            }
        }


        //public ActionResult Create()
        //{
        //    return View();
        //}

        public ActionResult Details(int? id)
        {
            if (Session["Adminn"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Reservas res = db.Reservas.Find(id);
                if (res == null)
                {
                    return HttpNotFound();
                }
                return View(res);
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
                Reservas cll = db.Reservas.Find(id);

                if (cll == null)
                {
                    return HttpNotFound();
                }
                ViewBag.cliente = new SelectList(db.Clientes, "rut", "nombre", cll.cliente);
                ViewBag.cancha = new SelectList(db.Canchas, "id_cancha", "nombre", cll.cancha);               
                return View(cll);

            }
            else
            {
                return Redirect("../Menu/Menu");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Reservas r)
        {
            if (ModelState.IsValid)
            {
                db.Entry(r).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Reservas");
            }

            ViewBag.cliente = new SelectList(db.Clientes, "rut", "nombre", r.cliente);
            ViewBag.cancha = new SelectList(db.Canchas, "id_cancha", "nombre", r.cancha);   
            return View(r);
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