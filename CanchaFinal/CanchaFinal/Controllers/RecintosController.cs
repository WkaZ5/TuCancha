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
    public class RecintosController : Controller
    {
        private TuCanchaEntities db = new TuCanchaEntities();
        // GET: Recintos
        public ActionResult Index()
        {
            if (Session["Adminn"] != null)
            {
                var can = db.Recintos.Include(u => u.Administradores).Include(u => u.Comunas);
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
                ViewBag.administrador = new SelectList(db.Administradores, "id_administrador", "nombre");
                ViewBag.comuna = new SelectList(db.Comunas, "id_comuna", "nombre");
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
        public ActionResult Create(Recintos recintos)
        {
            if (Session["Adminn"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Recintos.Add(recintos);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.administrador = new SelectList(db.Administradores, "id_administrador", "nombre", recintos.administrador);
                ViewBag.comuna = new SelectList(db.Comunas, "id_comuna", "nombre", recintos.comuna);
                return View(recintos);
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
                Recintos rec = db.Recintos.Find(id);
                if (rec == null)
                {
                    return HttpNotFound();
                }
                return View(rec);
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
                Recintos cll = db.Recintos.Find(id);

                if (cll == null)
                {
                    return HttpNotFound();
                }
                ViewBag.administrador = new SelectList(db.Administradores, "id_administrador", "nombre", cll.administrador);
                ViewBag.comuna = new SelectList(db.Comunas, "id_comuna", "nombre", cll.comuna);
                return View(cll);

            }
            else
            {
                return View("../Menu/Menu");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Recintos recc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recc).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.administrador = new SelectList(db.Administradores, "id_administrador", "nombre", recc.administrador);
            ViewBag.comuna = new SelectList(db.Comunas, "id_comuna", "nombre", recc.comuna);
            return View(recc);
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