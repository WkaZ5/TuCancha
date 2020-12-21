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
    public class JugadoresController : Controller
    {
        private TuCanchaEntities db = new TuCanchaEntities();
        //GET: Jugadores
        public ActionResult Index()
        {
            if (Session["Adminn"] != null)
            {
                var can = db.Jugadores.Include(u => u.Comunas).Include(u => u.Clientes);
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
               
                ViewBag.comuna = new SelectList(db.Comunas, "id_comuna", "nombre");
                ViewBag.cliente = new SelectList(db.Clientes, "rut", "nombre");
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
        public ActionResult Create(Jugadores jugadores)
        {
            if (Session["Adminn"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Jugadores.Add(jugadores);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                
                ViewBag.comuna = new SelectList(db.Comunas, "id_comuna", "nombre", jugadores.comuna);
                ViewBag.cliente = new SelectList(db.Clientes, "rut", "nombre",jugadores.cliente);
                return View(jugadores);
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
                Jugadores jug = db.Jugadores.Find(id);
                if (jug == null)
                {
                    return HttpNotFound();
                }
                return View(jug);
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
                Jugadores cll = db.Jugadores.Find(id);

                if (cll == null)
                {
                    return HttpNotFound();
                }
                //ViewBag.equipos = new SelectList(db.Equipos, "id_equipo", "nombre", cll.equipos);
                ViewBag.cliente = new SelectList(db.Clientes, "rut", "nombre",cll.cliente);
                ViewBag.comuna = new SelectList(db.Comunas, "id_comuna", "nombre", cll.comuna);
                return View(cll);

            }
            else
            {
                return Redirect("../Menu/Menu");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Jugadores juga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(juga).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.equipos = new SelectList(db.Equipos, "id_equipo", "nombre", juga.equipos);
            ViewBag.cliente = new SelectList(db.Clientes, "rut", "nombre",juga.cliente);
            ViewBag.comuna = new SelectList(db.Comunas, "id_comuna", "nombre", juga.comuna);
            return View(juga);
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